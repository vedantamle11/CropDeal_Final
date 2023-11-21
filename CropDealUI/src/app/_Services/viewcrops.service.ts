import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Userid } from '../_Models/userid';

@Injectable({
  providedIn: 'root'
})
export class ViewcropsService {
  apiurl ='https://localhost:7167/api/ViewCrop'


  constructor(private http:HttpClient) {
  }
  ViewCrop(){
    return this.http.get(this.apiurl)
  }
  ViewYourCrop(User:any){
    var id = new Userid();
    id.id=User;
    return this.http.post(this.apiurl,id)
  }

  ViewCropById(cropadid:any){
    return this.http.get('https://localhost:7167/api/CropOnSales/'+cropadid)
  }
}
