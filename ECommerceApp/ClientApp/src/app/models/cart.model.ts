import {Product} from './product.model';

export class CartItem {
  constructor(
    public id: number,
    public productId: number,
    public product: Product,
    public quantity: number
  ) {
  }
}
