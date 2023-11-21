import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  apiurl ='https://localhost:7167/api/Payment/'


  constructor(private http:HttpClient) { }

  payment(payment:any){
    return this.http.post(this.apiurl,payment)
  }
  invoice(userid:any){
    return this.http.get(this.apiurl+'DealerInvoice?UserId='+userid);
  }

  Farmerinvoice(userid:any){
    return this.http.get(this.apiurl+'FarmerInvoice?UserId='+userid);
  }


}
