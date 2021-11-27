import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //Depedency Injection
  constructor(private httpClient: HttpClient,
    private router: Router) { }

  //get a User
  getUserByPassword(user: User): Observable<any> {
    console.log(user.Username);
    console.log(user.Password);
    //https://localhost:44315/api/login/nithin/nithin123
    return this.httpClient.get(environment.apiUrl + "/api/login/getuser/" +
      user.Username + "/" + user.Password);
  }

  //Authorize return token with roleid and username
  public loginVerify(user : User){
    //calling web service url and passing username and password
    console.log("Attempt authenticate and authorize ::");
    console.log(user);
    return this.httpClient.get(environment.apiUrl+"/api/login/"+
    user.Username + "/" + user.Password)
  }

    //Logout
  public logout(){
    localStorage.removeItem('username');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('jwtToken');
    
  }
}
