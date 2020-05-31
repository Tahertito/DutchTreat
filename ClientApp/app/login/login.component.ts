import { Component } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';
@Component({
    selector: "the-login",
    templateUrl: "login.component.html"
})
export class Login {
    constructor(private data: DataService, private router: Router) { }
    public creds = {
        userName: "",
        password: ""
    }
    public errorMessage: string = "";
    public onLogin() {
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
    public checkLogging() {
        if (this.data.loginRiquired)
            return true;
        else
            return this.router.navigate(["/"]);
    }

}

