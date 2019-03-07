import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartserviceService {
  constructor(private http: HttpClient) { this.SetCartCount(); }
  baseUrl: string = 'http://localhost:50530/api/';
  private cartCountSource = new BehaviorSubject(0);
  cartCount = this.cartCountSource.asObservable();

  AddToCart(model: any): any {
    return this.http.post(this.baseUrl + 'Cart/AddToCart', model).pipe(
      map((response: any) => {
        const order = response;
        if (order) {
          localStorage.setItem('cartCount', order.items.length);
          this.SetCartCount();
          return order;
        }
      })
    );
  }

  SetCartCount() {
    this.cartCountSource.next(+localStorage.getItem('cartCount'));
  }

  RemoveProductFromCart(productId: string, orderId: string) {
    let removeCartDto = {
      productId: productId,
      orderId: orderId
    }

    return this.http.post(this.baseUrl + 'Cart/RemoveProductFromCart', removeCartDto);
  }

  GetCartBySessionId(sessionId: string) {
    return this.http.get(this.baseUrl + 'Cart/GetOrderBySessionId?sessionId=' + sessionId);
  }
}
