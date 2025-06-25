namespace BethanysPieShopHRM
{
    internal class Employee
    {
        public string firstName;
        public string lastName;
        public string email;

        public int hoursWorked;
        public double wage;
        public double hourlyRate;

        public DateTime birthday;


        public Employee(string first, string last, string employeeEmail, int hours, double startingWage, double hourly, DateTime birth)
        {
            firstName = first;
            lastName = last;
            email = employeeEmail;
            hoursWorked = hours;
            wage = startingWage;
            hourlyRate = hourly;
            birthday = birth;
        }


        public void PerformWork()
        {
            hoursWorked++;
            Console.WriteLine($"Total hours worked: {hoursWorked}");
        }

        public void PerformWork(int hours)
        {
            hoursWorked += hours;
            Console.WriteLine($"Total hours worked: {hoursWorked}");
        }
    }
}
