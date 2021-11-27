import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './shared/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authService : AuthService , private router : Router) { }
  title = 'Asset Management App';

//logout
logout(){
  this.authService.logout();
  this.router.navigateByUrl('login');
}

}

