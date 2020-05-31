import * as _ from 'lodash';
export class Order {
    constructor() {
        this.orderDate = new Date();
        this.items = new Array();
    }
    get subtotal() {
        return _.sum(this.items, i => i.unitPrice * i.quantity);
    }
}
export class OrderItem {
}
//# sourceMappingURL=order.js.map