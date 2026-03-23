using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */
            Console.WriteLine("--Sum--");
            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            
            
            Console.WriteLine("--Average--");
            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");
            
            
            Console.WriteLine("--Ascending--");
            //TODO: Order numbers in ascending order and print to the console
            var numbersAscending = numbers.OrderBy(x => x);
            foreach (var number in numbersAscending)
            {
                Console.WriteLine(number);
            }
            
            
            Console.WriteLine("--Descending--");
            //TODO: Order numbers in descending order and print to the console
            var numbersDescending = numbers.OrderByDescending(x => x);
            foreach (var number in numbersDescending)
            {
                Console.WriteLine($"{number}");
            }

            Console.WriteLine("--Greater Than 6--");
            //TODO: Print to the console only the numbers greater than 6
            var numbersAboveSix = numbers.Where(x => x > 6);
            foreach (var number in numbersAboveSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("--Print 4--");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var numbersDescending2 = numbers.Where(x => x < 4);
            foreach (var number in numbersDescending2)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("--To My Age--");
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 41;
            var numbersWithAgeDescending = numbers.OrderByDescending(n => n);
            foreach (var number in numbersWithAgeDescending)
            {
                Console.WriteLine(number);
            }
            

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("--Employee Name C and S--");
            var otherFilter = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName);

            
            foreach (var person in otherFilter)
            {
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine("--Fullname and Age--");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var nameAge = employees.Where(person => person.Age >= 26).OrderByDescending(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var item in nameAge)
            {
                Console.WriteLine($"Name: {item.FullName}, Age: {item.Age}");
            }

            Console.WriteLine("--Years of Experience--");
            
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumOfYears = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"Total Years of Experience:{sumOfYears.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Years of Experience:{sumOfYears.Average(x => x.YearsOfExperience)}");
            

           

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Linus", "Torvald", 56, 2)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
