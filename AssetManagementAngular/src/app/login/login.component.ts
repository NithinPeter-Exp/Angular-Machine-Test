import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../shared/login';
import {Jwtresponse} from '../shared/jwtresponse';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare Variables
  loginForm! : FormGroup;
  isSubmitted= false;
  loginUser: User = new User();
  error='';
  jwtResponse : any = new Jwtresponse()

  constructor(private formBuilder : FormBuilder,
    private router : Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group(
      {
        Username:['',[Validators.required, Validators.minLength(2)]],
        Password:['',[Validators.required]]
      }
    );
  }

  //Get controls
  get formControls(){
    return this.loginForm.controls;
  }

  //login --  verify credentials
  loginCredentials(){    
    console.log(this.loginForm.value);
    this.isSubmitted=true;

    //invalid
    if (this.loginForm.invalid) {
      return;
    }
    //valid
    //#region Valid    
    if (this.loginForm.valid) {

      //calling method from AuthService --Authorization and Authentication
      this.authService.loginVerify(this.loginForm.value)
      .subscribe(data => {
        console.log(data);
        //token with roleid and name
        this.jwtResponse=data;
        //either local/sesion
        sessionStorage.setItem("jwtToken" , this.jwtResponse.token)

        
        //check the RoleId based on it redirect to respective component
      if(this.jwtResponse.UserType == 'admin'){
        //logged As Admin
        console.log("ADMIN");
        //storing in local Storage / session Storage
        localStorage.setItem("username",this.jwtResponse.uname);
        localStorage.setItem("ACCESS_ROLE",this.jwtResponse.UserType.toString());
        sessionStorage.setItem("username",this.jwtResponse.uname);
        this.router.navigateByUrl('/admin');
      }
      else if (this.jwtResponse.UserType == 'manager') {
        //logged As Manager
        console.log("MANAGER");
        //storing in local Storage / session Storage
        localStorage.setItem("username",this.jwtResponse.uname);
        localStorage.setItem("ACCESS_ROLE",this.jwtResponse.UserType.toString());
        sessionStorage.setItem("username",this.jwtResponse.uname);
        this.router.navigateByUrl('/manager');
      }
      else{
        this.error="Sorry NOT allowed ... Invalid authorization "
      }

      },
      error =>{
        this.error="Invalid Username or Password. Try Again"
      }
      );
      
    }
    //#endregion    
  }

  //login verify   -- FOR TESTING ONLY
  loginVerifyTest(){
    if(this.loginForm.valid){
      this.authService.getUserByPassword(this.loginForm.value)
      .subscribe(
        (data) => {
          console.log(data);
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

}
