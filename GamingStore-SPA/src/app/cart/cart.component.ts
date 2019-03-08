import { Component, OnInit } from '@angular/core';
import { CartserviceService } from '../services/cartservice.service';
import { SelectItem } from 'primeng/components/common/selectitem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css',]
})
export class CartComponent implements OnInit {

  public cart: any;
  public sumAmount: number = 0;
  sortOptions: SelectItem[];
  sortKey: string;
  sortField: string;
  sortOrder: number;

  constructor(private cartservice: CartserviceService) { }

  ngOnInit() {
    let sessionId = "29212312213";

    this.cartservice.GetCartBySessionId(sessionId).subscribe(item => {
      this.cart = item;

      for (let i = 0; i < this.cart.cartItem.length; i++) {
        let item = this.cart.cartItem[i];
        this.sumAmount += item.price * item.quantity;
      }
      console.log(this.cart);
    });

    this.sortOptions = [
      { label: 'Newest First', value: '!year' },
      { label: 'Oldest First', value: 'year' },
      { label: 'Brand', value: 'brand' }
    ];

  }

  onSortChange(event) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
      this.sortOrder = -1;
      this.sortField = value.substring(1, value.length);
    }
    else {
      this.sortOrder = 1;
      this.sortField = value;
    }
  }

  removeItem(item, orderId) {

    this.cartservice.RemoveProductFromCart(item.prodID, orderId).subscribe(order => {
      const index = this.cart.cartItem.findIndex(product => product.prodID === item.prodID);
      this.cart.cartItem.splice(index, 1);
    });
  }



}