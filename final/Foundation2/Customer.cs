//This is the class about the customer.
class Customer {
    private string name;
    private Address address;

    public Customer(string name, Address address) {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA() {
        return address.IsInUSA();
    }

    //Here is where the program will get the customer's name and their address
    public string GetName() {
        return name;
    }

    public Address GetAddress() {
        return address;
    }
}