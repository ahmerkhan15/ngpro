import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../auth-service.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http:AuthServiceService,private route: Router) { }

  username: string;
  password: string;
    ngOnInit() {
    }
    login() : void {
      if(this.username == '' || this.password == ''){
        alert("Username or password cannot be empty");
      }
      this.http.Login({userName:this.username,passWord:this.password}).subscribe(
        next=> {this.route.navigate(['/']); console.log('Logged in successfully');
      },error=> {console.log('failed to login')}
        )

    }
}
