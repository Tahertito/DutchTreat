import * as _ from 'lodash';
export class Order {
    orderDate: Date = new Date();
    orderNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>();
    get subtotal() {
        return _.sum(this.items, i => i.unitPrice * i.quantity);
    }
}
export class OrderItem {
    id: number;
    quantity: number;
    unitPrice: number;
    productId: number;
    productCategory: string;
    productSize: string;
    productTitle: string;
    productArtist?: any;
    productArtId: string;

}