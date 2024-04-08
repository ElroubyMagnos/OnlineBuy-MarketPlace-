import { HttpClient } from '@angular/common/http';
import { Component, ElementRef } from '@angular/core';
import { PanelService } from '../panel.service';
import { Product } from '../product'
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  {

  SelectedProducts: Product[] = [];

  AllCount: number = 0;
  AllPrice: number = 0;
  AllWeight: number = 0;

  ProductsID: number[] = [];

  Products: Product[] = [];
  Categories: Category[] = [];

  WriteBill(billenter: HTMLInputElement)
  {
    if (!Number.isInteger(parseInt(billenter.value)))
    {
      billenter.value = '';
    }
  }

  Order()
  {
    if (this.SelectedProducts.length > 0)
    {
      this.Panel.CustomerProducts = this.SelectedProducts;
      this.route.navigate([`/bill/${Math.floor(Math.random() * 10000000)}`]);
    }
    else
    {
      alert('Please add a product in the bag on the right first');
    }
  }

  EnteredBillNumber(no: string)
  {
    this.route.navigate([`/bill/` + no]);
  }

  LoadPro()
  {
    this.http.post<Product[]>(`${this.Panel.BackendURL}/GetSiteProp/GetProducts`, this.ProductsID).subscribe(
      x =>
      {
        this.Products.push(...x);
  
        this.Products.forEach(x => {
          if (!this.ProductsID.includes(x.id))
          {
            this.ProductsID.push(x.id);
          }

          document.getElementById('buffering').style.display = 'none';
        });
      });

  }

  OpenBag(bag: HTMLElement)
  {
    
    if (bag.style.left != '0px')
    {
      bag.style.left = '0px';
    }
    else
    {
      bag.style.left = '-290px';
    }
  }

  constructor(private http: HttpClient, private Panel: PanelService, private elementRef: ElementRef, private route: Router)
  {
    this.elementRef.nativeElement.ownerDocument
            .body.style.backgroundColor = 'black';
            
    this.http.get<Category[]>(`${Panel.BackendURL}/GetCat`).subscribe(
      data => {
        this.Categories = data;
        this.LoadPro();
      }
    );

    window.onscroll = () =>
    {
      if ((window.innerHeight + Math.round(window.scrollY)) >= document.body.offsetHeight) 
      {
        this.LoadPro();
      }
    };
  }
  
}

interface Category
{
  name: string;
  product: any;
}