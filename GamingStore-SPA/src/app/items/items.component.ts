import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { DataserviceService } from '../dataservice.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  category:object;
  items:any;
  constructor(private data:DataserviceService, private route: ActivatedRoute) {
   }

  ngOnInit() {
        this.route.params.subscribe(param=> {
          this.category = param.id;
          this.data.GetProductByCategory(this.category).subscribe(x=> {this.items=x; console.log(x); });
        });
  }

}
