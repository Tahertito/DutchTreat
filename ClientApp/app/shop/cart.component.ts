import { Component } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';


@Component({
    selector: "the-cart",
    templateUrl: "./cart.component.html",
    styleUrls:[]
})
export class Cart {
    constructor(public data: DataService, private router: Router) { }

    public onCheckOut() {
        if (this.data.loginRiquired) {
            //force login
            return this.router.navigate(["login"]);
        }
        else {
            //continue ur shopping
            this.router.navigate(["checkout"]);
        }
    }
}

