import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl: string = 'http://localhost:50530/api/';

  constructor(private http: HttpClient) {  }
  

  getAllOrders()
  {
    return this.http.get(this.baseUrl + 'Orders');
  }
}
