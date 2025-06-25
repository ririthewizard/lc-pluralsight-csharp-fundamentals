namespace BethanysPieShopHRM.HR
{
    public record Address
    {
        private string street;
        private string houseNumber;
        private string city;
        private string state;
        private string zipCode;

        public Address(string street, string houseNumber, string city, string state, string zipCode)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
            }
        }

        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
            }
        }

    }
}
