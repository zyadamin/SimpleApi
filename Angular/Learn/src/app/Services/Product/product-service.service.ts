import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IOrderItemRequest } from 'src/app/Models/iorder-item-request';
import { IProduct } from 'src/app/Models/iproduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: IProduct[];
  private apiUrl = 'https://localhost:7199/api/Product'; // Base URL for API


  constructor(private http:HttpClient) {
  }


  listProducts(start:number,size:number): Observable<IProduct[]> {
    const params = new HttpParams()
      .set('start', start.toString())
      .set('size', size.toString());
    return this.http.post<IProduct[]>(`${this.apiUrl}/ListProducts`,null ,{ params });
  }

}
