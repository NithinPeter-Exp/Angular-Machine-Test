import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Asset } from '../shared/asset';
import { ManagerService } from '../shared/manager.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  //assign default page number
  page : number=1;
  filter:string;
  tempFilter:string;

  constructor(public managerService: ManagerService ,private router:Router) { }

  //lifecycle hook
  ngOnInit(): void {
    //Get all Assets From Service
    this.managerService.bindListAssets();
  }

  //Populate the form by clicking the td
  populateForm(asset :Asset){
    console.log(asset);
    this.managerService.formData=Object.assign({},asset);
  }

  //delete Employee
  deleteAsset(id:number){
    console.log("Deleting a Asset...");
    if(confirm('Are You Sure You Want to Delete ?')){
      this.managerService.deleteAsset(id).subscribe(
        (result)=>{
          console.log(result);
          this.managerService.bindListAssets();             
        },
        (error)=>{
        console.log(error)
        }
      );
    }    
  }

  //Update An employee
  updateAsset(aId : number){
    console.log(aId);
    this.router.navigate(['./addasset',aId])
  }

}
