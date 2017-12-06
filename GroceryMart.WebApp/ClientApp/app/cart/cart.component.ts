
import { Component } from '@angular/core';
import { Cart } from "../models/cart";
import { StoreService } from "../services/store";
declare const user: any;
@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html'
})
export class CartComponent {
    constructor(private cart:Cart,private storeService:StoreService) {
    }
    checkout() {
        if (user.userId > 0) {
            this.cart.UserId = user.userId;
            this.storeService.SaveCart(this.cart).subscribe((res: any) => {
                if (res._body != undefined) {
                    let cartId = res._body;
                    this.cart.CartId = cartId;
                    this.cart.checkoutPayUmoney(user);
                }
            });
        }
        else {
            window.location.href = '/account/login';
        }
    }
}

