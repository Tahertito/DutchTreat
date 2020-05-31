import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Product } from './product';
import { Observable } from 'rxjs';
import { Order, OrderItem } from './order';


@Injectable()
export class DataService {
    constructor(private http: HttpClient) { }
    public order: Order = new Order();
    public token: string = "";
    public tokenExpiration: Date;


    public get loginRiquired(): boolean {
        return this.token.length == 0 || this.tokenExpiration <= new Date();
    }
    public products: Product[] = [];
    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products").pipe(map((data: any[]) => {
            this.products = data; return true
        })
        );
    }
    addToOrder(newProduct: Product) {
        console.log(newProduct);
        let item: OrderItem = this.order.items.find(i => i.productId == newProduct.id);
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
    public login(creds) {
        return this.http.post("/account/createToken", creds)
            .pipe(map((response: any) => {

                this.token = response.token;
                console.log(response.expireIn);
                this.tokenExpiration = response.expireIn;
                return true;
            }));
    }
    public checkOut(order: Order) {
        console.log(this.token);
        return this.http.post("/api/orders", order, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(map((response: any) => {
            this.order = new Order();
            return true;
        }));
    }
}