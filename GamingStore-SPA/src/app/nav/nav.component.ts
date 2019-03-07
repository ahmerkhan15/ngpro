import { Component, OnInit } from '@angular/core';
import { DataserviceService } from '../services/dataservice.service';
import { CartserviceService } from '../services/cartservice.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  cartCount:any;

  constructor(private data:DataserviceService,private cartServ:CartserviceService,private route: ActivatedRoute) { }
  categoriesList:any;

  ngOnInit() {
    this.data.GetCategories().subscribe(x=> {this.categoriesList=x; });
    // this.cartCount =localStorage.getItem('cartCount') || 0;
    this.cartServ.cartCount.subscribe(x=> {this.cartCount = x;});
  }
  LoggedIn(){
    const user= localStorage.getItem('sessiontoken');
    return user != null
  }
  Logout(){
    localStorage.removeItem('sessiontoken');
  }
}
