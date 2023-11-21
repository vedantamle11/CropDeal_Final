import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  apiurl ='https://localhost:7167/api/UserProfiles'

  constructor(private http:HttpClient) { }
  proceedSignup(usercred:any){
    return this.http.post(this.apiurl,usercred)
  }

 update(userid:any,form:any){
  return this.http.put(this.apiurl+'/'+userid,form)
 }
  GetUsers(){
    return this.http.get(this.apiurl)
  }
  GetUserDetails(userid:any){
    return this.http.get(this.apiurl+'/'+userid)

  }
  loggedIn(){
    return !!localStorage.getItem('token')
  }
}
