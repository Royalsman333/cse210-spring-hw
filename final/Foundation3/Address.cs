//This is the address class
class Address {
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string state, string country) {
        this.streetAddress = street;
        this.city = city;
        this.stateOrProvince = state;
        this.country = country;
    }

    //This will make sure that the address is in the USA.
    public bool IsInUSA() {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetAddressDetails() {
        return $"{streetAddress}, {city}, {stateOrProvince}, {country}";
    }
}