
import { Component } from '@angular/core';
import { Cart } from "../models/cart";

@Component({
    selector: 'app-menu',
    templateUrl: 'app/menu'
})
export class MenuComponent {
    constructor(public cart: Cart) {
       
    }
}
