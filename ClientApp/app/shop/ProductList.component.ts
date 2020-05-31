import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Product } from "../shared/product";
@Component({
    selector: 'product_list',
    templateUrl: './ProductList.component.html',
    styleUrls: []
})
export class ProductList implements OnInit {
    constructor(private data: DataService) {
       
    }
    ngOnInit(): void {
        this.data.loadProducts().subscribe(success => {
            if (success) {
                this.products = this.data.products;
            }
        });
    }
    addProduct(p: Product) {
        this.data.addToOrder(p);
    }
    public products: Product[] = [];
}

