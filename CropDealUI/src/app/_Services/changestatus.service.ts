import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ChangestatusService {
  apiurl ='https://localhost:7167/api/User/'

  constructor(private http:HttpClient) { }

  changeStatus(userstatus:any){
    return this.http.post(this.apiurl,userstatus);
  }
}
