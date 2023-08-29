import { Component, OnInit } from '@angular/core';
import {CartItem} from "../../models/cart.model";
import {CartService} from "../../services/cart.service";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = [];

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cartService.getCartItems().subscribe({
      next: data => this.cartItems = data,
      error: () => alert('Failed to load cart items.')
    });
  }

  removeFromCart(id: number): void {
    this.cartService.removeFromCart(id).subscribe({
      next: () => this.cartItems = this.cartItems.filter(item => item.id !== id),
      error: () => alert('Failed to remove item from cart.')
    });
  }

  updateQuantity(id: number, newQuantity: number): void {
    this.cartService.updateQuantity(id, newQuantity).subscribe({
      next: () => {
        const item = this.cartItems.find(item => item.id === id);
        if (item) {
          item.quantity = newQuantity;
        }
      },
      error: () => alert('Failed to update item quantity.')
    });
  }
}
