import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { DataserviceService } from '../dataservice.service';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {
  itemID:any;
  itemobj:object;

  constructor(private data:DataserviceService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(param=> this.itemID = param.id);
    this.data.GetProductByID(this.itemID).subscribe(x=> {this.itemobj=x; console.log(x); });
  }

}
