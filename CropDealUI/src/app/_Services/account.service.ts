import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class AccountService {
apiurl ='https://localhost:7167/api/Login/'
  constructor(private http:HttpClient) { }

  proceedLogin(usercred:any){
    return this.http.post(this.apiurl+"login",usercred)

  }
  GetToken(){
    return localStorage.getItem('token')||''
  }



}
