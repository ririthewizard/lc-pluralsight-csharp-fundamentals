namespace BethanysPieShopHRM.HR
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private string email;

        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate;

        private DateTime birthDay;
        private const int minimalHoursWorkedUnit = 1;

        private Address address;

        public static double taxRate = 0.15;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public DateTime Birthday
        {
            get { return birthDay; }
            set
            {
                birthDay = value;
            }
        }

        public int NumberOfHoursWorked
        {
            get { return numberOfHoursWorked; }
            set
            {
                if (value > 0)
                {
                    numberOfHoursWorked = value;
                }
            }
        }

        public double Wage
        {
            get { return wage; }
            private set
            {
                if (value > 0)
                {
                    wage = value;
                }
            }
        }

        public double? HourlyRate
        {
            get { return hourlyRate; }
            private set
            {
                if (value > 0)
                {
                    hourlyRate = value;
                }
            }
        }

        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        public Employee(string firstName, string lastName, string email, DateTime birthday)
            : this(firstName, lastName, email, birthday, 0)
        {

        }


        public Employee(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate,
                string street, string houseNumber, string city, string state, string zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthDay;
            HourlyRate = hourlyRate ?? 10;

            Address = new Address(street, houseNumber, city, state, zip);
        }

        public Employee(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthDay;
            HourlyRate = hourlyRate ?? 10;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: {FirstName}\tLast name: {LastName}\nEmail: {Email}\nBirthday: {Birthday}\nHourly rate: {HourlyRate}");
        }
    }
}
