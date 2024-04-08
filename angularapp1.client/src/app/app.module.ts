import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { PanelService } from './panel.service';
import { HomeComponent } from './home/home.component';
import { BillComponent } from './bill/bill.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    BillComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'bill/:id', component: BillComponent },
    ])
  ],
  providers: [PanelService],
  bootstrap: [AppComponent],
})
export class AppModule { }
