import { __decorate } from "tslib";
import { Component } from '@angular/core';
let Cart = class Cart {
    constructor(data, router) {
        this.data = data;
        this.router = router;
    }
    onCheckOut() {
        if (this.data.loginRiquired) {
            //force login
            return this.router.navigate(["login"]);
        }
        else {
            //continue ur shopping
            this.router.navigate(["checkout"]);
        }
    }
};
Cart = __decorate([
    Component({
        selector: "the-cart",
        templateUrl: "./cart.component.html",
        styleUrls: []
    })
], Cart);
export { Cart };
//# sourceMappingURL=cart.component.js.map