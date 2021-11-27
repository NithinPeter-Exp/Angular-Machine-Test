import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './login';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  //create instance of client
  formData: User = new User();  
  users:User[];

  constructor(private httpClient: HttpClient) { }

  //Get All Assets
  bindListUsers(){
    this.httpClient.get(environment.apiUrl+"/api/UserRegistration")
      .toPromise().then(response => 
      this.users=response as User[]
    );
  }

  //INSERT
  insertUser(user :User): Observable<any>{
    return this.httpClient.post(environment.apiUrl+"/api/UserRegistration",user);
  }

  //UPDATE
  updateUser(user :User): Observable<any>{
    return this.httpClient.put(environment.apiUrl+"/api/UserRegistration",user);
  }

  //DELETE
  deleteUser(id:number){
    return this.httpClient.delete(environment.apiUrl+"/api/UserRegistration/"+id);
  }

  //GET a particular User
  getUser(userId : number): Observable<any>{
    return this.httpClient.get(environment.apiUrl+"/api/UserRegistration/" + userId);
  
  }
  
}
