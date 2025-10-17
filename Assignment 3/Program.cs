using System;

namespace Assignment3
{
    // ================== MAIN PROGRAM ==================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========== ASSIGNMENT 3 DEMO ===========");

            // ------------------- Q1 & Q2: Instance -------------------
            Console.WriteLine("\n===== Instance Class (Q1 & Q2) =====");

            Instance emp = new Instance { Name = "Abhishek", Age = 30, Salary = 50000 };
            emp.DisplayEmployeeDetails();

            Instance acc = new Instance { AccountNumber = "12345", Name = "John" };
            acc.Deposit(2000);
            acc.Withdraw(500);
            acc.DisplayAccountDetails();


            // ------------------- Q3 & Q4: Static -------------------
            Console.WriteLine("\n===== Static Class (Q3 & Q4) =====");

            int[] numbers = { 10, 20, 30, 40 };
            Console.WriteLine("Average: " + Static.CalculateAverage(numbers));
            Static.LogMessage("This is a log from Static class.");


            // ------------------- Q5 & Q6: Partial -------------------
            Console.WriteLine("\n===== Partial Class (Q5 & Q6) =====");

            Partial person = new Partial { FirstName = "Abhishek", LastName = "Sharma" };
            person.PrintFullName();

            Partial emp2 = new Partial { EmployeeName = "Sam", BaseSalary = 30000 };
            Console.WriteLine($"Employee: {emp2.EmployeeName}, Final Salary: {emp2.CalculateSalary(5000, 2000)}");


            // ------------------- Q7 & Q8: Abstract -------------------
            Console.WriteLine("\n===== Abstract Class (Q7 & Q8) =====");

            Abstract shape1 = new Circle { Radius = 5 };
            Console.WriteLine("Circle Area: " + shape1.CalculateArea());

            Abstract shape2 = new Rectangle { Length = 4, Width = 6 };
            Console.WriteLine("Rectangle Area: " + shape2.CalculateArea());

            Animal dog = new Dog { Name = "Tommy", Age = 3 };
            dog.Speak();

            Animal cat = new Cat { Name = "Kitty", Age = 2 };
            cat.Speak();


            // ------------------- Q9 & Q10: Sealed -------------------
            Console.WriteLine("\n===== Sealed Class (Q9 & Q10) =====");

            Car car = new Car();
            car.StartEngine();
            car.Drive();
            car.StopEngine();

            SavingsAccount sa = new SavingsAccount { AccountNumber = "98765", Balance = 10000 };
            Console.WriteLine($"Account: {sa.AccountNumber}, Balance: {sa.Balance}");
            Console.WriteLine("Interest (5%): " + sa.CalculateInterest(5));

            Console.WriteLine("\n=========== END OF ASSIGNMENT 3 ===========");
        }
    }

    // ================== Q1 & Q2: INSTANCE CLASS ==================
    class Instance
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public string AccountNumber { get; set; }
        public double Balance { get; private set; }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount} deposited successfully.");
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient balance!");
            }
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Salary: {Salary}");
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine($"Account: {AccountNumber}, Name: {Name}, Balance: {Balance}");
        }
    }

    // ================== Q3 & Q4: STATIC CLASS ==================
    static class Static
    {
        public static double CalculateAverage(int[] numbers)
        {
            double sum = 0;
            foreach (int n in numbers) sum += n;
            return sum / numbers.Length;
        }

        public static void LogMessage(string msg)
        {
            Console.WriteLine("[LOG] " + msg);
        }
    }

    // ================== Q5 & Q6: PARTIAL CLASS ==================
    partial class Partial
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void PrintFullName()
        {
            Console.WriteLine($"Full Name: {FirstName} {LastName}");
        }
    }

    partial class Partial
    {
        public string EmployeeName { get; set; }
        public double BaseSalary { get; set; }

        public double CalculateSalary(double bonus, double allowance)
        {
            return BaseSalary + bonus + allowance;
        }
    }

    // ================== Q7 & Q8: ABSTRACT CLASS ==================
    abstract class Abstract
    {
        public abstract double CalculateArea();
    }

    class Circle : Abstract
    {
        public double Radius { get; set; }
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }

    class Rectangle : Abstract
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public override double CalculateArea() => Length * Width;
    }

    // Animal abstraction
    abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract void Speak();
    }

    class Dog : Animal
    {
        public override void Speak() => Console.WriteLine($"{Name} the Dog says: Woof!");
    }

    class Cat : Animal
    {
        public override void Speak() => Console.WriteLine($"{Name} the Cat says: Meow!");
    }

    // ================== Q9 & Q10: SEALED CLASS ==================
    sealed class Car
    {
        public void StartEngine() => Console.WriteLine("Car engine started.");
        public void Drive() => Console.WriteLine("Car is driving...");
        public void StopEngine() => Console.WriteLine("Car engine stopped.");
    }

    sealed class SavingsAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public double CalculateInterest(double rate)
        {
            return Balance * rate / 100;
        }
    }
}
