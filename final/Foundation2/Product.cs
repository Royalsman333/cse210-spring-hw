//This is the Product class. This has the name, product id, the price, and the quantity of the products being ordered.
class Product {
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string id, double price, int quantity) {
        this.name = name;
        this.productId = id;
        this.price = price;
        this.quantity = quantity;
    }

//This will get the total cost (by multiplying the price of the product with the quantity)
    public double GetTotalCost() {
        return price * quantity;
    }

    public string GetName() {
        return name;
    }

    public string GetProductId() {
        return productId;
    }

    public double GetPrice() {
        return price;
    }

    public int GetQuantity() {
        return quantity;
    }
}