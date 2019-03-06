import { Component, OnInit } from '@angular/core';
import { DataserviceService } from '../dataservice.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  cartCount:any;

  constructor(private data:DataserviceService,private route: ActivatedRoute) { }
  categoriesList:any;

  ngOnInit() {
    this.data.GetCategories().subscribe(x=> {this.categoriesList=x; });
    this.cartCount=2;
  }
  LoggedIn(){
    const user= localStorage.getItem('sessiontoken');
    return user != null
  }
  Logout(){
    localStorage.removeItem('sessiontoken');
  }
}
