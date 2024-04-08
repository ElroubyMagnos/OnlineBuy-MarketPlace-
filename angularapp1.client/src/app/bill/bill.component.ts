import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { PanelService } from '../panel.service';
import { HttpClient } from '@angular/common/http';
import { Product } from '../product';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css']
})
export class BillComponent {
  ValidBillNumber: boolean = false;
  BillNumber: number = 0;
  Branches: Branch[] = [];
  Addresshidden: boolean = true;
  Billsend: BillSend;
  Lock: boolean = false;
  BuyedItems: Product[] = [];

  CurrentBranch: string = '';

  copyInputMessage(inputElement: HTMLInputElement){
    inputElement.select();
    document.execCommand('copy');
    inputElement.setSelectionRange(0, 0);
  }
  
  constructor(private route: ActivatedRoute, private panel: PanelService, private router: Router, private http: HttpClient)
  {
    this.BillNumber = parseInt(route.snapshot.paramMap.get('id'));

    this.http.get<boolean>(panel.BackendURL + `/Particles/CheckBillNumber/${this.BillNumber}`).subscribe(x => 
    {
        this.ValidBillNumber = x;
        this.http.get<Branch[]>(panel.BackendURL + `/Particles/GetBranches`).subscribe(x => this.Branches = x);

        if (panel.CustomerProducts.length == 0 && !this.ValidBillNumber)
        {
          router.navigate(['/']);
          return;
        }

        if (this.ValidBillNumber)
        {
          this.Lock = true;

          this.http.get<BillSend>(panel.BackendURL + '/Particles/SendFatora/' + this.BillNumber)
          .subscribe(x =>
          {
            (document.getElementById('branchcontainer') as HTMLSelectElement).value = x.branchName;

            var Selected = '';

            if (x.delivery)
            {
              Selected = 'Delivery';
            }
            else
            {
              Selected = 'TakeAway';
            }

            (document.getElementById('deliveryortakeaway') as HTMLSelectElement).value = Selected;

            (document.getElementById('BAddress') as HTMLInputElement).value = x.buyerAddress;

            (document.getElementById('BPhone') as HTMLInputElement).value = x.buyerPhone.toString();

            this.http.get<Product[]>(`${this.panel.BackendURL}/Particles/GetAllProductsID/${this.BillNumber}`)
            .subscribe(x => {
              this.BuyedItems = x;
            });

            var Interval = setInterval(() => 
            {
              clearInterval(Interval)

              var deliveryortakeaway = (document.getElementById('deliveryortakeaway') as HTMLSelectElement);

              this.http.get<BillChat[]>(`${panel.BackendURL}/Particles/${deliveryortakeaway.value == 'Reserve' ? 'GetResMsgs' : 'GetBillMsgs'}/${this.BillNumber}`).subscribe(
                x => {
                  var chatarea = document.getElementById('chatarea') as HTMLTextAreaElement;
                  chatarea.value = '';

                  x.forEach(element => {
                    chatarea.value += `${element.sender}: ${element.message}\n`;
                  });
                }
              );
            }, 2000)

          });
        }
        else
        {
          this.BuyedItems = panel.CustomerProducts;
        }
    });
  }

  pressEnter(word: HTMLInputElement, chararea: HTMLTextAreaElement, Res: boolean)
  {
   this.SendChatToEmployee(word, chararea, Res)
  }

  SendChatToEmployee(msg: HTMLInputElement, chararea: HTMLTextAreaElement, ForReserve: boolean)
  {
    if (msg.value.length > 0)
    {
      if (ForReserve)
      {
        this.Lock = true;
        
        this.http.get<boolean>(`${this.panel.BackendURL}/Particles/SendResChat/${msg.value}/${this.BillNumber}`)
        .subscribe(x =>
        {
          if (x)
          {
            chararea.value += this.BillNumber + ": " + msg.value + '\n';
          }
          msg.value = ''; 
        }
      );
      }
      else
      {
          this.http.get<boolean>(`${this.panel.BackendURL}/Particles/SendBillChat/${msg.value}/${this.BillNumber}`)
          .subscribe(x =>
          {
            if (x)
            {
              chararea.value += this.BillNumber + ": " + msg.value + '\n';
            }
            msg.value = ''; 
          }
        );
      }
    }
  }
  
  SendBill(braname: HTMLSelectElement, delort: HTMLSelectElement, address: string, phone: string)
  {
    if (this.BillNumber <= 0)
    {
      return;
    }

    if (braname.value != 'Unselected' && delort.value != 'Unselected')
    {
      if (delort.value != 'Delivery')
      {
        address = '';
      }

      if (phone.length == 11 && (phone.startsWith('012') || phone.startsWith("011") || phone.startsWith("010") || phone.startsWith("015")))
      {
        var Allprice = 0;
        var AllWeight = 0;
        var AllProducts = '';

        this.panel.CustomerProducts.forEach(element => {
          Allprice += element.price;
          AllWeight += element.weight;
          AllProducts += `${element.id},`;
        });

        this.Billsend = 
        {
          allPrice: Allprice,
          allWeight: AllWeight,
          number: this.BillNumber,
          allProductsID: AllProducts,
          delivery: delort.value == 'Delivery',
          buyerAddress: address,
          buyerPhone: +phone,
          branchName: braname.value,
        };

        this.http.post<boolean>(`${this.panel.BackendURL}/Particles/ReceiveFatora`, this.Billsend)
        .subscribe(
          x =>
          {
            this.router.navigate(['/']);
          }
        );
      }
      else
      {
        alert('Please enter a valid phone number');
        return;
      }
    }
    else
    {
      alert('Please fill all fields');
    }
  }

  Reserve: boolean = false;
}

interface Branch
{
  id: number;
  maxWeight: string;
  ourAddress: string;
  ourPhone: number;
  branchName: string;
}

interface BillSend
{
  allPrice: number;
  allWeight: number;
  number: number;
  allProductsID: string;
  delivery: boolean;
  buyerAddress: string;
  buyerPhone: number;
  branchName: string;
}

interface BillChat
{
  sender: string,
  message: string,
  billNumber: number
}