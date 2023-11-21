import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetCropDto } from '../_Models/crops.models';

@Injectable({
  providedIn: 'root',
})
export class CropsService {
  apiurl = 'https://localhost:7167/api/Crops/';

  constructor(private http: HttpClient) {}

  getcrops() {
    return this.http.get(this.apiurl);
  }

  getCropById(id: number) {
    let idStr = id.toString();
    return this.http.get(this.apiurl + '/' + idStr);
  }
}
