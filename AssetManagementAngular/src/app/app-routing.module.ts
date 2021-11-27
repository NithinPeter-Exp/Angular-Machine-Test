import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { ManagerComponent } from './manager/manager.component';
import { AuthGuard } from './shared/auth.guard';
import {AddassetComponent} from './manager/addasset/addasset.component'

const routes: Routes = [
  { path: '', redirectTo:"/login", pathMatch:'full'},
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent , canActivate:[AuthGuard], data:{role : 'admin'} },
  { path: 'manager', component: ManagerComponent , canActivate:[AuthGuard], data:{role : 'manager'} },
  { path: 'addasset', component: AddassetComponent , canActivate:[AuthGuard], data:{role : 'manager'} },
  { path: 'addasset/:aId', component: AddassetComponent , canActivate:[AuthGuard], data:{role : 'manager'} },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
