import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http:HttpClient){}
  baseUrl:string='http://localhost:50530/api/';

  Login(model:any){
    return this.http.post(this.baseUrl+'Auth/Login',model).pipe(
      map((response:any)=> {
        const user = response;
        if(user){
          localStorage.setItem('sessiontoken',user.token);
        }
      })
    );
  }

  
}
