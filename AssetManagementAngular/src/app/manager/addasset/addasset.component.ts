import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Asset } from 'src/app/shared/asset';
import { ManagerService } from 'src/app/shared/manager.service';

@Component({
  selector: 'app-addasset',
  templateUrl: './addasset.component.html',
  styleUrls: ['./addasset.component.css']
})
export class AddassetComponent implements OnInit {

  aId:number;
  asset : Asset = new Asset();  
  isSubmitted = false;

  constructor(public managerService: ManagerService , 
    private router:Router,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
    //get empId from Activated Route
    this.aId=this.route.snapshot.params['aId'];

    if (this.aId !=0 || this.aId!=null) {
      this.managerService.getAsset(this.aId).subscribe(
        data => {
          console.log(data);  
          this.managerService.formData=data;
        }
      );
    }
    else{
      console.log("There is a Error");
    }
  }

  onSubmit(form: NgForm) {
    this.isSubmitted=true;  
    console.log(form.value);        
    let addId=this.managerService.formData.AmId;
    
    if (addId == 0 || addId==null) {
      //Insert 
      this.insertAssetRecord(form);
           
    }
    else{
      //Update
      console.log("Updating Record...");
      this.updateAssetRecord(form);
    }
  }
  //clear all contents at Initialization  
  resetForm(form?: NgForm){
    if(form!=null){
      form.resetForm();
    }
  }

  //INSERT
  insertAssetRecord(form?: NgForm){
    console.log("Inserting a Record...");
    this.managerService.insertAsset(form.value).subscribe(
      (result)=>{
        console.log(result);              
        this.resetForm(form);        
      }      
    );
    window.location.reload()
    
  }

  //UPDATE
  updateAssetRecord(form?: NgForm){
    console.log("Updating a Record...");
    this.managerService.updateAsset(form.value).subscribe(
      (result)=>{
        console.log(result);
        this.resetForm(form);        
        this.managerService.bindListAssets();        
      }
    );
    window.location.reload()
  }
}
