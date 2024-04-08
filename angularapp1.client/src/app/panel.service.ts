import { Injectable } from '@angular/core';
import { Product } from '../app/product'

@Injectable({
  providedIn: 'root'
})
export class PanelService {
 
  CustomerProducts: Product[] = [];

  BackendURL = "https://localhost:7162";
}
