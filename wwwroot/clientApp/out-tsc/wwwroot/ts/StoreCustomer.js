class StoreCustomer {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    set name(val) {
        this.fullName = this.firstName + " " + this.lastName;
    }
    get name() {
        this.name = "test";
        return this.fullName;
    }
    ShowName() {
        alert(this.name);
    }
}
//# sourceMappingURL=StoreCustomer.js.map