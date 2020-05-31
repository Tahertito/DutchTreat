import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ProductList } from './shop/ProductList.component';
import { DataService } from './shared/dataService';
import { Cart } from './shop/cart.component';
import { Shop } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';
import { Login } from "./login/login.component";
import { format } from 'util';
let routs = [

    { path: "", component: Shop },
    { path: "checkout", component: Checkout },
    { path: "login", component:Login }
];

@NgModule({
    declarations: [
        AppComponent,
        ProductList,
        Cart,
        Shop,
        Checkout,
        Login


    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(routs, {
            useHash: true
        })
    ],
    providers: [
        DataService,

    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
