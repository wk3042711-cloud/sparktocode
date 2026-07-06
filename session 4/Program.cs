using System;

namespace session_4
{
    class Program
    {
        // ==========================================
        // TASK 1 - Personalized Welcome Function
        // ==========================================
        static void PrintWelcome(string name)
        {
            Console.WriteLine("Welcome, " + name + "! We are glad to have you here.");
        }

        // ==========================================
        // TASK 2 - Square Number Function
        // ==========================================
        static int Square(int number)
        {
            return number * number;
        }

        // ==========================================
        // TASK 3 - Celsius to Fahrenheit Function
        // ==========================================
        static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // ==========================================
        // TASK 4 - Fixed Menu Display Function
        // ==========================================
        static void DisplayMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1) Start");
            Console.WriteLine("2) Help");
            Console.WriteLine("3) Exit");
        }

        // ==========================================
        // TASK 5 - Even or Odd Function
        // ==========================================
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // ==========================================
        // TASK 6 - Rectangle Area & Perimeter Functions
        // ==========================================
        static double CalculateArea(double length, double width)
        {
            return length * width;
        }

        static double CalculatePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        // ==========================================
        // TASK 7 - Grade Letter Function
        // ==========================================
        static string GetGradeLetter(int score)
        {
            if (score >= 90)
            {
                return "A";
            }
            else if (score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if (score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        // ==========================================
        // TASK 8 - Countdown Function
        // ==========================================
        static void Countdown(int startNumber)
        {
            for (int i = startNumber; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Liftoff!");
        }

        // ==========================================
        // MAIN METHOD
        // ==========================================
        static void Main(string[] args)
        {
            // ==========================================
            // TASK 1 - Personalized Welcome Function
            // ==========================================
            Console.WriteLine("========== TASK 1 ==========");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            PrintWelcome(userName);
            Console.WriteLine();

            // ==========================================
            // TASK 2 - Square Number Function
            // ==========================================
            Console.WriteLine("========== TASK 2 ==========");

            Console.Write("Enter a number: ");
            int squareNumber = int.Parse(Console.ReadLine());
            int squaredResult = Square(squareNumber);
            Console.WriteLine("Square of " + squareNumber + " is: " + squaredResult);
            Console.WriteLine();

            // ==========================================
            // TASK 3 - Celsius to Fahrenheit Function
            // ==========================================
            Console.WriteLine("========== TASK 3 ==========");

            Console.Write("Enter temperature in Celsius: ");
            double celsiusInput = double.Parse(Console.ReadLine());
            double fahrenheitResult = CelsiusToFahrenheit(celsiusInput);
            Console.WriteLine(celsiusInput + "°C is " + fahrenheitResult + "°F");
            Console.WriteLine();

            // ==========================================
            // TASK 4 - Fixed Menu Display Function
            // ==========================================
            Console.WriteLine("========== TASK 4 ==========");

            DisplayMenu();
            Console.WriteLine();

            // ==========================================
            // TASK 5 - Even or Odd Function
            // ==========================================
            Console.WriteLine("========== TASK 5 ==========");

            Console.Write("Enter a number: ");
            int evenCheckNumber = int.Parse(Console.ReadLine());
            bool isEvenResult = IsEven(evenCheckNumber);

            if (isEvenResult)
            {
                Console.WriteLine(evenCheckNumber + " is Even");
            }
            else
            {
                Console.WriteLine(evenCheckNumber + " is Odd");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 6 - Rectangle Area & Perimeter Functions
            // ==========================================
            Console.WriteLine("========== TASK 6 ==========");

            Console.Write("Enter length of rectangle: ");
            double rectLength = double.Parse(Console.ReadLine());

            Console.Write("Enter width of rectangle: ");
            double rectWidth = double.Parse(Console.ReadLine());

            double area = CalculateArea(rectLength, rectWidth);
            double perimeter = CalculatePerimeter(rectLength, rectWidth);

            Console.WriteLine("Area: " + area);
            Console.WriteLine("Perimeter: " + perimeter);
            Console.WriteLine();

            // ==========================================
            // TASK 7 - Grade Letter Function
            // ==========================================
            Console.WriteLine("========== TASK 7 ==========");

            Console.Write("Enter your score: ");
            int examScore = int.Parse(Console.ReadLine());
            string gradeLetter = GetGradeLetter(examScore);
            Console.WriteLine("Your grade is: " + gradeLetter);
            Console.WriteLine();

            // ==========================================
            // TASK 8 - Countdown Function
            // ==========================================
            Console.WriteLine("========== TASK 8 ==========");

            Console.Write("Enter a starting number: ");
            int startCountdown = int.Parse(Console.ReadLine());
            Countdown(startCountdown);
            Console.WriteLine();

          
        }
    }
}