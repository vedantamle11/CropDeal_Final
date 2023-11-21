import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCropDto } from '../_Models/crops.models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7167/api/Crops';

  constructor(private http: HttpClient) { }

  getCrops(searchQuery: string): Observable<GetCropDto[]> {
    const params = new HttpParams().set('searchQuery', searchQuery);
    return this.http.get<GetCropDto[]>(`${this.apiUrl}/searchQuery/`, { params });
  }

  getProductById(cropId: any) {
    return this.http.get(`https://localhost:7167/api/ViewProducts/${cropId}`);
  }

}
