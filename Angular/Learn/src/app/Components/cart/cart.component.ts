import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { IOrderInfoRequest } from 'src/app/Models/iorder-info-request';
import { IOrderViewModel } from 'src/app/Models/iorder-view-model';
import { OrderService } from 'src/app/Services/Order/order-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  order: IOrderViewModel
  items: IOrderViewModel[]
  totalAmount: number
  userInfoForm: FormGroup
  error:string;
  

  constructor(private _orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router) {

    this.userInfoForm = new FormGroup({

      name: new FormControl('', [Validators.required]),
      mobileNumber: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),

    });
  }

  ngOnInit() {

    let orderId = +this.route.snapshot.paramMap.get('id');
    this.getOrder(orderId);
  }

  getOrder(id: number): void {
    this._orderService.getOrderById(id).subscribe({
      next: (data: IOrderViewModel) => {
        if (data.id == 0) {
          this.router.navigate(['/Home']);
        }
        this.order = data;
        this.items = this.order.items;
        this.totalAmount = this.order.totalAmount;
        console.log('order loaded:', this.order);
      },
      error: (err) => {
        console.error('Error loading order:', err);
      }
    });
  }

  ConfirmOrder() {

    let orderInfo: IOrderInfoRequest = {
      id: Number(this.route.snapshot.paramMap.get('id')),
      customerAddress: this.name.value,
      customerName: this.address.value,
      mobileNumber: this.mobileNumber.value
    };

    this._orderService.confirmOrder(orderInfo).subscribe({
      next: (data: number) => {
        this.router.navigate(['/Home']);
      },
      error: (err) => {
        this.error=err.error;
        console.error('Error Confirm Order:', err);
      }
    });

  }

  get name() {
    return this.userInfoForm.get('name');
  }

  get mobileNumber() {
    return this.userInfoForm.get('mobileNumber');
  }

  get address() {
    return this.userInfoForm.get('address');
  }
}
