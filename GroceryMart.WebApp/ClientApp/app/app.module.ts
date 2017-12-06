import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AppComponent }  from './app.component';
import { AppRoutingModule, routedComponents } from "./app.routing";
import { MenuComponent } from "./menu/menu.component";
import { GlobalConfig } from "./services/globalconfig";
import { StoreService } from "./services/store";
import { Cart } from "./models/cart";

@NgModule({
    imports: [BrowserModule, AppRoutingModule, HttpModule, FormsModule ],
    declarations: [AppComponent, MenuComponent, routedComponents],
    providers: [GlobalConfig, StoreService,Cart],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
