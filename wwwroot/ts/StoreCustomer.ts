 class StoreCustomer {
    constructor(private firstName: string, private lastName: string) { }
    private fullName: string;
    set name(val: string) {
        this.fullName = this.firstName + " " + this.lastName;
    }
     get name() {
         this.name="test";
        return this.fullName;
    }
    public ShowName(): void {
        alert(this.name);
    }

}