import { __decorate } from "tslib";
import { Component } from "@angular/core";
let Checkout = class Checkout {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
    }
    onCheckout() {
        // TODO
        this.data.checkOut(this.data.order).subscribe(response => {
            if (response) {
                return this.router.navigate(["/"]);
            }
        }, err => this.errorMessage = "faild to checkout");
    }
};
Checkout = __decorate([
    Component({
        selector: "checkout",
        templateUrl: "checkout.component.html",
        styleUrls: ['checkout.component.css']
    })
], Checkout);
export { Checkout };
//# sourceMappingURL=checkout.component.js.map