import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CropsonsaleService {
  apiurl ='https://localhost:7167/api/CropOnSales/'

  constructor(private http:HttpClient) { }

  croponsale(cropad:any){
    return this.http.post(this.apiurl,cropad)
  }

}
