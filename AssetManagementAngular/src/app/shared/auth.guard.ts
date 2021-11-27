import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  //Dependency Injection
  constructor(private authService : AuthService , 
    private router : Router){}
  
    canActivate(
      next: ActivatedRouteSnapshot): boolean {
        //declaring expected role and current role
        const expectedRole = next.data.role;
        const currentRole = localStorage.getItem("ACCESS_ROLE");
        
        //check weather expected role and current role are same. Give access if they are same
        if (expectedRole != currentRole){
          this.router.navigateByUrl('login');
          return false;
        }
      return true;
    }
  
}
