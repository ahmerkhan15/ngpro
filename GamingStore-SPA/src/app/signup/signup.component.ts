import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators } from '@angular/forms';
import {AuthServiceService}from '../services/auth-service.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  myForm:FormGroup;
  // Form state
  loading = false;
  success = false;
  constructor(private http:AuthServiceService,private fb:FormBuilder) {}

  ngOnInit() {
    this.myForm=this.fb.group({
      email:['', [Validators.required,Validators.email]],
      firstName:['',[Validators.required,Validators.minLength(3)]],
      lastName:[''],
      userName:['',[Validators.required]],
      password:['',[Validators.required,Validators.minLength(6)]],
      postalCode:['',[Validators.required,Validators.minLength(3)]],
      address:['',[Validators.required,Validators.minLength(5)]],
      cellphone:['',[Validators.required,Validators.minLength(5)]],
    });
  }

  submitHandler() {
    this.loading = true;
    const formValue = this.myForm.value;
    console.log(formValue);
    this.http.Signup(formValue).subscribe(
      next=> {this.success = true; console.log('signup success');}
  )}

}
