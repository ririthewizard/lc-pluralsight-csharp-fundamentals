
namespace Methods
{
    internal class Utilities
    {
        public static double CalculateYearlyWage(double hourlyWage, double numHoursWorked)
        {
            //Console.WriteLine($"Yearly wage: {hourlyWage * numHoursWorked}");
            return hourlyWage * numHoursWorked;
        }
        public static double CalculateYearlyWage(double hourlyWage, double numHoursWorked, double bonus)
        {
            //Console.WriteLine($"Yearly wage: {hourlyWage * numHoursWorked}");
            return hourlyWage * numHoursWorked + bonus;
        }
    }
}
