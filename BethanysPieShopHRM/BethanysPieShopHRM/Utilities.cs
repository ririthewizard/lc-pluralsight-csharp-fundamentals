﻿using BethanysPieShopHRM.HR;
using System.Text;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
        private static string directory = @"data/BethanysPieShopHRM/";
        private static string fileName = "employees.txt";

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating an employee");

            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine("1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior researcher");
            Console.Write("Your selection: ");
            string employeeType = Console.ReadLine();

            if (employeeType != "1" && employeeType != "2" && employeeType != "3"
                && employeeType != "4" && employeeType != "5")
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the birth day: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());//ex. 2/16/2008

            Console.Write("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate);//we will assume here that input is in the correct format

            Employee employee = null;

            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, birthDay, rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthDay, rate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, birthDay, rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthDay, rate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email, birthDay, rate);
                    break;
            }

            employees.Add(employee);

            Console.WriteLine("Employee created!\n\n");
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter the Employee ID you want to visualize: ");

                int selectedId = int.Parse(Console.ReadLine());
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.DisplayEmployeeDetails();
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not the correct format to enter an ID!\n\n");
                Console.ResetColor();
            }
        }

        internal static void CheckForExistingEmployeeFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound)
            {
                Console.WriteLine("An existing file with this Employee's data has been found");
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Directory {directory} is ready for saving files");
                    Console.ResetColor();
                }
            }
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayEmployeeDetails();
            }
        }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            try
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    //now read the file
                    string[] employeesAsString = File.ReadAllLines(path);
                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        string[] employeeSplits = employeesAsString[i].Split(';');
                        string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);//firstName:Bethany
                        string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                        string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                        DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                        double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));
                        string employeeType = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);

                        Employee employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "3":
                                employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "4":
                                employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "5":
                                employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                        }


                        employees.Add(employee);

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                    //Console.ResetColor();
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(iex.Message);
                //Console.ResetColor();
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                //Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);
                //Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();

            }
        }

        internal static void SaveEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder builder = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string type = GetEmployeeType(employee);
                builder.Append($"firstName:{employee.FirstName};");
                builder.Append($"lastName:{employee.LastName};");
                builder.Append($"email:{employee.Email};");
                builder.Append($"birthday:{employee.BirthDay};");
                builder.Append($"hourlyRate:{employee.HourlyRate};");
                builder.Append($"type:{type};");
                builder.Append(Environment.NewLine);
            }

            File.WriteAllText(path, builder.ToString());
        }

        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";
        }
    }
}
