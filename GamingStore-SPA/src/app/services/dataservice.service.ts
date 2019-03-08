import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {
  constructor(private http:HttpClient){}
  baseUrl:string='http://localhost:50530/api/';
  GetCategories(){
    return this.http.get(this.baseUrl+'Categories');
  }

  GetProductByCategory(catid){
    return this.http.get(this.baseUrl+'Products/GetItemsByCategory?id='+catid);
  }

  GetProducts(){
    return this.http.get(this.baseUrl+'Products');
  }

  GetProductByID(prodid){
    return this.http.get(this.baseUrl+'Products/GetById?id='+prodid);
  }
}
