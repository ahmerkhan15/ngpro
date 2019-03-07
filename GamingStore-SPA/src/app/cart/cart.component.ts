import { Component, OnInit } from '@angular/core';
import { CartserviceService } from '../services/cartservice.service';
import { SelectItem } from 'primeng/components/common/selectitem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public cart:{};
  sortOptions: SelectItem[];
  sortKey: string;
  sortField: string;

  sortOrder: number;
  selectedCar:any;
  displayDialog:boolean;


  constructor(private cartservice: CartserviceService) { }

  ngOnInit() {
    let sessionId = "19212312213";

    this.cartservice.GetCartBySessionId(sessionId).subscribe(item => { this.cart = item; console.log(this.cart); });

    this.sortOptions = [
      { label: 'Newest First', value: '!year' },
      { label: 'Oldest First', value: 'year' },
      { label: 'Brand', value: 'brand' }
    ];
  }

  selectCar(event: Event, car: any) {
    this.selectedCar = car;
    this.displayDialog = true;
    event.preventDefault();
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

  onDialogHide() {
    this.selectedCar = null;
  }

}
