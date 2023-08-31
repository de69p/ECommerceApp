import {Component, OnInit} from '@angular/core';
import {Product} from "../../models/product.model";
import {ProductService} from "../../services/product.service";
import {CartService} from "../../services/cart.service";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  showCategories = false;

  constructor(private productService: ProductService, private cartService: CartService) {
  }

  filterProducts(type: string | null): void {
    this.productService.getProducts(type).subscribe({
      next: data => this.products = data,
      error: () => alert('Failed to load products.')
    });
  }


  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: data => this.products = data,
      error: () => alert('Failed to load products.')
    });
  }

  addToCart(product: Product): void {
    this.cartService.addToCart(product).subscribe({
      next: () => alert('Product added to cart'),
      error: () => alert('Failed to add product to cart.')
    });
  }

}
