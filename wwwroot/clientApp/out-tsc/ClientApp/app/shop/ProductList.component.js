import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ProductList = class ProductList {
    constructor(data) {
        this.data = data;
        this.products = [];
    }
    ngOnInit() {
        this.data.loadProducts().subscribe(success => {
            if (success) {
                this.products = this.data.products;
            }
        });
    }
    addProduct(p) {
        this.data.addToOrder(p);
    }
};
ProductList = __decorate([
    Component({
        selector: 'product_list',
        templateUrl: './ProductList.component.html',
        styleUrls: []
    })
], ProductList);
export { ProductList };
//# sourceMappingURL=ProductList.component.js.map