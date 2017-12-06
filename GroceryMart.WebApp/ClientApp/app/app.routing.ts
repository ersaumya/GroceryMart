import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { StoreComponent } from "./store/store.component";
import { CartComponent } from "./cart/cart.component";

const routes: Routes = [
    { path: '', component: StoreComponent },
    { path: 'cart', component: CartComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule { }

export const routedComponents = [StoreComponent, CartComponent]