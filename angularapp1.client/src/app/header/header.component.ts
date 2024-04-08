import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, inject } from '@angular/core';
import { Route, Router } from '@angular/router';
import { PanelService } from '../panel.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  FB: string = '';
  WA: string = '';

  NavFB()
  {
    if (this.FB.length > 0)
    this.route.navigateByUrl(this.FB);
  }

  constructor(private Panel: PanelService, private http: HttpClient, private route: Router)
  {
    var fbxml = new XMLHttpRequest();
    fbxml.open("GET", `${Panel.BackendURL}/GetSiteProp/GetFacebook`);
    fbxml.onreadystatechange = ()=> {
        if (fbxml.readyState == 4 && fbxml.status == 200)
        {
            this.FB = fbxml.responseText;
        }
    };
    fbxml.send();

    var waxml = new XMLHttpRequest();
    waxml.open("GET", `${Panel.BackendURL}/GetSiteProp/GetWhatsApp`);
    waxml.onreadystatechange = ()=> {
        if (waxml.readyState == 4 && waxml.status == 200)
        {
            this.WA = waxml.responseText;
        }
    };
    waxml.send();

    var logoxml = new XMLHttpRequest();
    logoxml.open("GET", `${Panel.BackendURL}/GetSiteProp/GetLogo`);
    logoxml.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200)
        {
            (document.getElementById("logoimage") as HTMLImageElement).src = `data:image/png;base64,${this.responseText}`;
        }
    };
    logoxml.send();
  }
}
