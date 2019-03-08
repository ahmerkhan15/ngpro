import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataserviceService } from '../services/dataservice.service';
import { v4 as uuid } from 'uuid';
import { CartserviceService } from 'src/app/services/cartservice.service';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {
  itemID: any;
  product: any;
  productImages: any[];
  selectedItem: any;

  constructor(private data: DataserviceService, private route: ActivatedRoute, private cartservice: CartserviceService) {
  }

  ngOnInit() {
    this.route.params.subscribe(param => this.itemID = param.id);
    this.data.GetProductByID(this.itemID).subscribe(x => {
      this.product = x;
      this.productImages = [];

      for (let i = 0; i < this.product.images.length; i++) {
        let image = this.product.images[i];
        this.productImages.push({ source: image, thumbnail: image, title: image });
      }

    });
  }

  AddToCart(item): void {
    event.stopPropagation();
    this.selectedItem = item;
    var browserID = this.GenerateUniqueBrowserID();
    this.cartservice.AddToCart({ prodID: this.selectedItem.prodID, quantity: 1, price: this.selectedItem.price, sessionID: browserID, cstID: "" }).subscribe(
      next => {
        alert('Added to cart'); console.log(next);
      }, error => { alert('something went wrong'); }
    )
  }

  GenerateUniqueBrowserID(): string {
    var browid = localStorage.getItem('browserID');
    if (browid != null) { return browid; }
    browid = uuid();
    localStorage.setItem("browserID", browid);
    return browid;
  }

}
