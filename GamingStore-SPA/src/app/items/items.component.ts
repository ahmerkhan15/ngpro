import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { DataserviceService } from '../services/dataservice.service';
import { CartserviceService } from '../services/cartservice.service';
import { v4 as uuid } from 'uuid';
import {AddToCartDTO} from '../DTO/AddToCartDTO'

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  category:object;
  items:any;
  selectedItem:any;  
  
  constructor(private data:DataserviceService, private cartservice:CartserviceService, private route: ActivatedRoute) {}
  
  ngOnInit() {
        this.route.params.subscribe(param=> {
          this.category = param.id;
          this.data.GetProductByCategory(this.category).subscribe(x=> {this.items=x; });
        });
  }

  AddToCart(item):void{
    event.stopPropagation();
    this.selectedItem = item;
    console.log(this.selectedItem);     
    // this.atc.prodID ="";// this.selectedItem.prodID;
    //this.atc.quantity = 1;
    // this.atc.price = this.selectedItem.price;
    // this.atc.sessionID = this.selectedItem.prodID;
     //this.atc.cstID = "";
     var browserID = this.GenerateUniqueBrowserID();
     console.log(browserID);
     this.cartservice.AddToCart({prodID: this.selectedItem.prodID,quantity:1,price:this.selectedItem.price,sessionID:browserID, cstID:""}).subscribe(
      next=> {console.log('Logged in successfully');
    },error=> {console.log('failed to login')}
      )
  }

  GenerateUniqueBrowserID():string{
    var browid=localStorage.getItem('browserID');
    if(browid != null){return browid;}
    browid = uuid();
    localStorage.setItem("browserID",browid);
    return browid;
  }

}
