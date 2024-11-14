import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IOrderItemRequest } from 'src/app/Models/iorder-item-request';
import { IProduct } from 'src/app/Models/iproduct';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {

  @Input() product: IProduct;
  @Output() newItemEvent = new EventEmitter<IOrderItemRequest>();
  constructor() { }

  ngOnInit() {
  }


  addToCart(id: number, quantity: string) {

    let item: IOrderItemRequest = {

      productId: id,
      quantity: Number(quantity)
    }
    this.newItemEvent.emit(item);


  }

}
