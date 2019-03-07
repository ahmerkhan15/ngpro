import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CartserviceService {
  constructor(private http:HttpClient){}
  baseUrl:string='http://localhost:50530/api/';

  AddToCart(model:any){
    return this.http.post(this.baseUrl+'Cart/AddToCart',model).pipe(
      map((response:any)=> {
        const order = response;
        if(order){
          console.log(order);
        }
      })
    );
  }
}
