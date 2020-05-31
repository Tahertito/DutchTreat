import { __decorate } from "tslib";
import { Component } from "@angular/core";
let Login = class Login {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.creds = {
            userName: "",
            password: ""
        };
        this.errorMessage = "";
    }
    onLogin() {
        this.data.login(this.creds).subscribe(success => {
            if (success) {
                if (this.data.order.items.length == 0) {
                    console.log("navigate to home");
                    return this.router.navigate[""];
                }
                else {
                    console.log("navigate to checkout");
                    return this.router.navigate(["checkout"]);
                }
            }
        }, err => this.errorMessage = "fiald to login");
    }
    checkLogging() {
        if (this.data.loginRiquired)
            return true;
        else
            return this.router.navigate(["/"]);
    }
};
Login = __decorate([
    Component({
        selector: "the-login",
        templateUrl: "login.component.html"
    })
], Login);
export { Login };
//# sourceMappingURL=login.component.js.map