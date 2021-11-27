import { HttpClient } from '@angular/common/http';
import { AssertNotNull } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {Asset} from './asset'

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  //create instance of client
  formData: Asset = new Asset();  
  assets:Asset[];

  constructor(private httpClient: HttpClient) { }

  //Get All Assets
  bindListAssets(){
    this.httpClient.get(environment.apiUrl+"/api/asset")
      .toPromise().then(response => 
      this.assets=response as Asset[]
    );
  }

  //INSERT
  insertAsset(asset :Asset): Observable<any>{
    return this.httpClient.post(environment.apiUrl+"/api/asset",asset);
  }

  //UPDATE
  updateAsset(asset :Asset): Observable<any>{
    return this.httpClient.put(environment.apiUrl+"/api/asset",asset);
  }

  //DELETE
  deleteAsset(id:number){
    return this.httpClient.delete(environment.apiUrl+"/api/asset/"+id);
  }

  //GET a particular Client
  getAsset(assetId : number): Observable<any>{
    return this.httpClient.get(environment.apiUrl+"/api/asset/" + assetId);
  
  }

}
