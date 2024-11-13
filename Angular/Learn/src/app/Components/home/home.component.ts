import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forEach } from '@angular/router/src/utils/collection';
import { IOrderItemRequest } from 'src/app/Models/iorder-item-request';
import { IOrderRequest } from 'src/app/Models/iorder-request';
import { IProduct } from 'src/app/Models/iproduct';
import { OrderService } from 'src/app/Services/Order/order-service.service';
import { ProductService } from 'src/app/Services/Product/product-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  products: IProduct[];
  orderItems: IOrderItemRequest[] = [];
  startIndex: number = 0;
  pageSize: number = 8;


  constructor(private _productService: ProductService,
    private _orderService: OrderService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.startIndex = 0;
    this.loadProducts(this.startIndex, this.pageSize);
  }

  addToCart(id: number, quantity: string) {

    const quantityNumber = Number(quantity);
    // Check if the product is already in the cart
    const existingItem = this.orderItems.find(item => item.productId == id);
    const product = this.products.find(item => item.id == id);


    if (existingItem) {
      // Update the quantity if it already exists, checking against stock
      if (quantityNumber <= product.quantityInStock) {
        existingItem.quantity = quantityNumber;
        console.log(`Updated quantity for product ${product.name} to ${quantity}`);
      } else {
        console.warn(`Only ${product.quantityInStock} items available in stock`);
      }
    } else {
      // Add new item if it doesn't exist in the cart, checking stock
      if (quantityNumber <= product.quantityInStock) {
        this.orderItems.push({
          productId: product.id,
          quantity: quantityNumber,
        });
        console.log(`Added ${quantity} of ${product.name} to the cart`);
      } else {
        console.warn(`Only ${product.quantityInStock} items available in stock`);
      }
    }
  }

  createOrder() {

    let orderRequest: IOrderRequest = {
      items: this.orderItems
    };

    this._orderService.createOrder(orderRequest).subscribe({
      next: (orderId: number) => {
        console.log('order created:', orderId);
        this.router.navigate(['/Cart', orderId]);
      },
      error: (err) => {
        console.error('Error loading products:', err);
      }
    });
  }

  loadProducts(start: number, size: number): void {
    this._productService.listProducts(start, size).subscribe({
      next: (data: IProduct[]) => {
        data.forEach(element => {

         let product= this.orderItems.find(x=>x.productId == element.id)
          element.quantityToAdd = (product == null) ? 0 : product.quantity 
        })
        this.products = data;
        console.log('Products loaded:', this.products);
      },
      error: (err) => {
        console.error('Error loading products:', err);
      }
    });
  }

  next() {
    this.startIndex += this.pageSize;
    this.loadProducts(this.startIndex, this.pageSize);
  }

  previous() {
    if (this.startIndex > 0) {
      this.startIndex -= this.pageSize;
      this.loadProducts(this.startIndex, this.pageSize);
    }
  }
  
}
