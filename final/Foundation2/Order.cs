//This is the order class. This is where all of the information about the order will be combined.
class Order {
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer) {
        this.customer = customer;
    }

    public void AddProduct(Product product) {
        products.Add(product);
    }

    public double CalculateTotalCost() {
        double totalCost = 0;
        foreach (var product in products) {
            totalCost += product.GetTotalCost();
        }

        // This is where the system will add an additional cost if customer is outside of the USA.
        if (customer.IsInUSA()) {
            totalCost += 5; // Shipping cost if the customer is from the USA
        } else {
            totalCost += 35; // Shipping cost if the customer is not from the USA
        }

        return totalCost;
    }

    public string GetPackingLabel() {
        string label = "Packing Label:\n";
        foreach (var product in products) {
            label += $"Product Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel() {
        string label = "Shipping Label:\n";
        label += $"Customer Name: {customer.GetName()}\n";
        label += $"Customer Address:\n{customer.GetAddress().GetAddressDetails()}";
        return label;
    }
}