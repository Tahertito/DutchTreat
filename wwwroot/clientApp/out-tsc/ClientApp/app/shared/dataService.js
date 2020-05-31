import { __decorate } from "tslib";
import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order, OrderItem } from './order';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.order = new Order();
        this.token = "";
        this.products = [];
    }
    get loginRiquired() {
        return this.token.length == 0 || this.tokenExpiration <= new Date();
    }
    loadProducts() {
        return this.http.get("/api/products").pipe(map((data) => {
            this.products = data;
            return true;
        }));
    }
    addToOrder(newProduct) {
        console.log(newProduct);
        let item = this.order.items.find(i => i.productId == newProduct.id);
        if (item) {
            console.log("prod is exist");
            item.quantity++;
        }
        else {
            console.log("prod not found");
            item = new OrderItem();
            item.productArtId = newProduct.artId;
            item.productArtist = newProduct.artist;
            item.productCategory = newProduct.category;
            item.productId = newProduct.id;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.quantity = 1;
            item.unitPrice = newProduct.price;
            this.order.items.push(item);
        }
    }
    login(creds) {
        return this.http.post("/account/createToken", creds)
            .pipe(map((response) => {
            this.token = response.token;
            console.log(response.expireIn);
            this.tokenExpiration = response.expireIn;
            return true;
        }));
    }
    checkOut(order) {
        console.log(this.token);
        return this.http.post("/api/orders", order, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(map((response) => {
            this.order = new Order();
            return true;
        }));
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map