import { Component } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {

    constructor(public data: DataService, private router: Router) {
  }
    public errorMessage = "";
  onCheckout() {
      // TODO
      this.data.checkOut(this.data.order).subscribe(response => {
          if (response) {
              return this.router.navigate(["/"]);
          }
      }, err => this.errorMessage="faild to checkout");
  }
}