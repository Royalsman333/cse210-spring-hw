//Here is the address class
class Address {
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    //This will combine all of the information about an address.
    public Address(string street, string city, string state, string country) {
        this.streetAddress = street;
        this.city = city;
        this.stateOrProvince = state;
        this.country = country;
    }


    //To see if the customer is in the USA, this will set the value that was inputed into the country slot.
    public bool IsInUSA() {
        //I also ignores the capitalization of USA, just incase the customer inputs usa, or Usa, instead of USA.
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

   //This will return the value together
    public string GetAddressDetails() {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}