var StoreCustomer = /** @class */ (function () {
    function StoreCustomer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            this.name = "test";
            return this.fullName;
        },
        set: function (val) {
            this.fullName = this.firstName + " " + this.lastName;
        },
        enumerable: true,
        configurable: true
    });
    StoreCustomer.prototype.ShowName = function () {
        alert(this.name);
    };
    return StoreCustomer;
}());
//# sourceMappingURL=StoreCustomer.js.map