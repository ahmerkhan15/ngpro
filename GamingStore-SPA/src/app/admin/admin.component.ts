import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';
import { CartserviceService } from 'src/app/services/cartservice.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  public orders: any;
  public sumAmount: number = 0;
  public selectedOrder: any;
  public cols: any;

  displayDetail: boolean = false;

  constructor(private orderService: OrderService, private cartservice: CartserviceService) { }

  ngOnInit() {
    this.orderService.getAllOrders().subscribe(order => {
      this.orders = order;
      for (let i = 0; i < this.orders.length; i++) {
        let order = this.orders[i];
        order.productCount = order.items ? order.items.length : 0;
      }
    })


    this.cols = [

      { field: 'orderID', header: 'Order #' },
      { field: 'customerID', header: 'Customer' },
      { field: 'productCount', header: 'Total Items' },
      { field: 'total', header: 'Total' }
    ];
  }

  showDetailsDialog(order) {

    this.cartservice.GetCartBySessionId(order.sessionID).subscribe(item => {
      this.selectedOrder = item;

      for (let i = 0; i < this.selectedOrder.cartItem.length; i++) {
        let item = this.selectedOrder.cartItem[i];
        this.sumAmount += item.price * item.quantity;
      }
      
      this.displayDetail = true;
    });


  }



}
