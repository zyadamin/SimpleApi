import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as internal from 'assert';
import { Observable } from 'rxjs';
import { IOrderInfoRequest } from 'src/app/Models/iorder-info-request';
import { IOrderRequest } from 'src/app/Models/iorder-request';
import { IOrderViewModel } from 'src/app/Models/iorder-view-model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl = 'https://localhost:7199/api/Order'; // Base URL for API

  constructor(private http:HttpClient) { }

  createOrder(order:IOrderRequest):Observable<number>{
    return this.http.post<number>(`${this.apiUrl}/CreateOrder`,order);
  }

  getOrderById(id:number):Observable<IOrderViewModel>{
    const params = new HttpParams()
    .set('id', id.toString())
    return this.http.post<IOrderViewModel>(`${this.apiUrl}/GetOrder`,null,{params});
  }

  confirmOrder(order:IOrderInfoRequest): Observable<number>{
    return this.http.post<number>(`${this.apiUrl}/ConfirmOrder`,order);
  }
}
