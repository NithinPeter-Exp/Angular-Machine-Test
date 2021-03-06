import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    console.log("Intercepting here...")
    let token = sessionStorage.getItem('jwtToken');
    if(sessionStorage.getItem('username') && sessionStorage.getItem("jwtToken")){
      request = request.clone(
        {
          setHeaders:{
            Authorization : `Bearer ${token}` //passing Token in header
          }
        })
    }
    return next.handle(request);
  }
}
