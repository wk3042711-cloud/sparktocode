using System;

namespace _1_7_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // TASK 1 - Personal Info Card
            // ==========================================
            Console.WriteLine("========== TASK 1 ==========");

            string name = "Sara";
            int age = 21;
            double height = 1.65;
            bool isStudent = true;

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Student: " + isStudent);
            Console.WriteLine();

            // ==========================================
            // TASK 2 - Rectangle Calculator
            // ==========================================
            Console.WriteLine("========== TASK 2 ==========");

            Console.Write("Enter the length of the rectangle: ");
            double length = double.Parse(Console.ReadLine());

            Console.Write("Enter the width of the rectangle: ");
            double width = double.Parse(Console.ReadLine());

            double area = length * width;
            double perimeter = 2 * (length + width);

            Console.WriteLine("Area: " + area);
            Console.WriteLine("Perimeter: " + perimeter);
            Console.WriteLine();

            // ==========================================
            // TASK 3 - Even or Odd Checker
            // ==========================================
            Console.WriteLine("========== TASK 3 ==========");

            Console.Write("Enter a whole number: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine(number + " is Even");
            }
            else
            {
                Console.WriteLine(number + " is Odd");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 4 - Voting Eligibility
            // ==========================================
            Console.WriteLine("========== TASK 4 ==========");

            Console.Write("Enter your age: ");
            int voterAge = int.Parse(Console.ReadLine());

            Console.Write("Do you hold a valid national ID? (yes/no): ");
            string idResponse = Console.ReadLine().ToLower();
            bool hasValidId = idResponse == "yes";

            if (voterAge >= 18 && hasValidId)
            {
                Console.WriteLine("You are eligible to vote.");
            }
            else
            {
                Console.WriteLine("You are not eligible to vote.");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 5 - Grade Letter Lookup
            // ==========================================
            Console.WriteLine("========== TASK 5 ==========");

            Console.Write("Enter a grade letter (A, B, C, D, or F): ");
            char grade = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent");
                    break;
                case 'B':
                    Console.WriteLine("Very Good");
                    break;
                case 'C':
                    Console.WriteLine("Good");
                    break;
                case 'D':
                    Console.WriteLine("Pass");
                    break;
                case 'F':
                    Console.WriteLine("Fail");
                    break;
                default:
                    Console.WriteLine("Invalid grade");
                    break;
            }
            Console.WriteLine();

            // ==========================================
            // TASK 6 - Temperature Converter
            // ==========================================
            Console.WriteLine("========== TASK 6 ==========");

            Console.Write("Enter temperature in Celsius: ");
            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = (celsius * 9 / 5) + 32;
            string weatherClassification;

            if (celsius < 10)
            {
                weatherClassification = "Cold";
            }
            else if (celsius >= 10 && celsius <= 30)
            {
                weatherClassification = "Mild";
            }
            else
            {
                weatherClassification = "Hot";
            }

            Console.WriteLine("Fahrenheit: " + fahrenheit.ToString("F2"));
            Console.WriteLine("Weather: " + weatherClassification);
            Console.WriteLine();

            // ==========================================
            // TASK 7 - Movie Ticket Pricing
            // ==========================================
            Console.WriteLine("========== TASK 7 ==========");

            Console.Write("Enter your age: ");
            int movieAge = int.Parse(Console.ReadLine());

            string category;
            double ticketPrice;

            if (movieAge >= 0 && movieAge <= 12)
            {
                category = "Children";
                ticketPrice = 2.000;
            }
            else if (movieAge >= 13 && movieAge <= 59)
            {
                category = "Adults";
                ticketPrice = 5.000;
            }
            else if (movieAge >= 60)
            {
                category = "Seniors";
                ticketPrice = 3.000;
            }
            else
            {
                category = "Invalid Age";
                ticketPrice = 0;
            }

            Console.WriteLine("Category: " + category);
            Console.WriteLine("Price: " + ticketPrice.ToString("F3") + " OMR");
            Console.WriteLine();

            // ==========================================
            // TASK 8 - Restaurant Bill with Membership Discount
            // ==========================================
            Console.WriteLine("========== TASK 8 ==========");

            Console.Write("Enter total bill amount: ");
            double totalBill = double.Parse(Console.ReadLine());

            Console.Write("Are you a loyalty member? (yes/no): ");
            string memberResponse = Console.ReadLine().ToLower();
            bool isMember = memberResponse == "yes";

            double discountAmount = 0;
            double finalAmount = totalBill;

            if (totalBill > 20 && isMember)
            {
                discountAmount = totalBill * 0.15;
                finalAmount = totalBill - discountAmount;
            }

            Console.WriteLine("Original Bill: " + totalBill.ToString("F3") + " OMR");
            Console.WriteLine("Discount Amount: " + discountAmount.ToString("F3") + " OMR");
            Console.WriteLine("Final Amount: " + finalAmount.ToString("F3") + " OMR");
            Console.WriteLine();

            // ==========================================
            // TASK 9 - Day Name Finder
            // ==========================================
            Console.WriteLine("========== TASK 9 ==========");

            Console.Write("Enter a number (1-7) for day of the week: ");
            int dayNumber = int.Parse(Console.ReadLine());

            switch (dayNumber)
            {
                case 1:
                    Console.WriteLine("Sunday");
                    break;
                case 2:
                    Console.WriteLine("Monday");
                    break;
                case 3:
                    Console.WriteLine("Tuesday");
                    break;
                case 4:
                    Console.WriteLine("Wednesday");
                    break;
                case 5:
                    Console.WriteLine("Thursday");
                    break;
                case 6:
                    Console.WriteLine("Friday");
                    break;
                case 7:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Invalid day number");
                    break;
            }
            Console.WriteLine();

            // ==========================================
            // TASK 10 - Mini Calculator
            // ==========================================
            Console.WriteLine("========== TASK 10 ==========");

            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /, %): ");
            char operatorChar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            double result = 0;
            bool validOperation = true;

            switch (operatorChar)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero");
                        validOperation = false;
                    }
                    break;
                case '%':
                    if (num2 != 0)
                    {
                        result = num1 % num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero");
                        validOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    validOperation = false;
                    break;
            }

            if (validOperation && operatorChar != '/' && operatorChar != '%')
            {
                Console.WriteLine("Result: " + result);
            }
            else if (validOperation && (operatorChar == '/' || operatorChar == '%'))
            {
                Console.WriteLine("Result: " + result);
            }
            Console.WriteLine();

            // ==========================================
            // TASK 11 - Loan Eligibility System
            // ==========================================
            Console.WriteLine("========== TASK 11 ==========");

            Console.Write("Enter your age: ");
            int loanAge = int.Parse(Console.ReadLine());

            Console.Write("Enter your monthly income (in OMR): ");
            double monthlyIncome = double.Parse(Console.ReadLine());

            Console.Write("Do you have an existing loan? (yes/no): ");
            string existingLoanResponse = Console.ReadLine().ToLower();
            bool hasExistingLoan = existingLoanResponse == "yes";

            bool ageValid = loanAge >= 21 && loanAge <= 60;
            bool incomeValid = monthlyIncome >= 400;
            bool noExistingLoan = !hasExistingLoan;

            if (ageValid && incomeValid && noExistingLoan)
            {
                Console.WriteLine("You are eligible for the loan.");
            }
            else
            {
                Console.Write("You are not eligible. Reason(s): ");
                if (!ageValid) Console.Write("Age out of range ");
                if (!incomeValid) Console.Write("Income too low ");
                if (!noExistingLoan) Console.Write("Has existing loan ");
                Console.WriteLine();
            }
            Console.WriteLine();

            // ==========================================
            // TASK 12 - Shipping Cost Calculator
            // ==========================================
            Console.WriteLine("========== TASK 12 ==========");

            Console.Write("Enter region code (A, B, or C): ");
            char regionCode = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("Enter package weight (in kg): ");
            double weight = double.Parse(Console.ReadLine());

            double baseCost = 0;
            double extraCharge = 0;
            bool validRegion = true;

            switch (regionCode)
            {
                case 'A':
                    baseCost = 1.000;
                    break;
                case 'B':
                    baseCost = 3.000;
                    break;
                case 'C':
                    baseCost = 7.000;
                    break;
                default:
                    Console.WriteLine("Invalid region");
                    validRegion = false;
                    break;
            }

            if (validRegion)
            {
                if (weight > 10)
                {
                    extraCharge = 5.000;
                }
                else if (weight > 5)
                {
                    extraCharge = 2.000;
                }

                double totalShippingCost = baseCost + extraCharge;

                Console.WriteLine("Base Cost: " + baseCost.ToString("F3") + " OMR");
                Console.WriteLine("Extra Charge: " + extraCharge.ToString("F3") + " OMR");
                Console.WriteLine("Total Shipping Cost: " + totalShippingCost.ToString("F3") + " OMR");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 13 - Triangle Type Classifier
            // ==========================================
            Console.WriteLine("========== TASK 13 ==========");

            Console.Write("Enter side 1 length: ");
            double side1 = double.Parse(Console.ReadLine());

            Console.Write("Enter side 2 length: ");
            double side2 = double.Parse(Console.ReadLine());

            Console.Write("Enter side 3 length: ");
            double side3 = double.Parse(Console.ReadLine());

            bool isValidTriangle = (side1 + side2 > side3) &&
                                   (side1 + side3 > side2) &&
                                   (side2 + side3 > side1);

            if (!isValidTriangle)
            {
                Console.WriteLine("Not a valid triangle.");
            }
            else
            {
                if (side1 == side2 && side2 == side3)
                {
                    Console.WriteLine("Equilateral Triangle");
                }
                else if (side1 == side2 || side1 == side3 || side2 == side3)
                {
                    Console.WriteLine("Isosceles Triangle");
                }
                else
                {
                    Console.WriteLine("Scalene Triangle");
                }
            }
            Console.WriteLine();

            // ==========================================
            // TASK 14 - Online Store Checkout
            // ==========================================
            Console.WriteLine("========== TASK 14 ==========");

            Console.Write("Enter product code (1, 2, or 3): ");
            int productCode = int.Parse(Console.ReadLine());

            double unitPrice = 0;
            string productName = "";
            bool validProduct = true;

            switch (productCode)
            {
                case 1:
                    productName = "Headphones";
                    unitPrice = 8.500;
                    break;
                case 2:
                    productName = "Keyboard";
                    unitPrice = 12.000;
                    break;
                case 3:
                    productName = "Mouse";
                    unitPrice = 5.000;
                    break;
                default:
                    Console.WriteLine("Invalid product code");
                    validProduct = false;
                    break;
            }

            if (validProduct)
            {
                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Do you have a discount coupon? (yes/no): ");
                string couponResponse = Console.ReadLine().ToLower();
                bool hasCoupon = couponResponse == "yes";

                double subtotal = unitPrice * quantity;
                double discount = 0;

                if (hasCoupon && subtotal > 20)
                {
                    discount = subtotal * 0.10;
                }

                double afterDiscount = subtotal - discount;
                double tax = afterDiscount * 0.05;
                double finalTotal = afterDiscount + tax;

                Console.WriteLine("Subtotal: " + subtotal.ToString("F3") + " OMR");
                Console.WriteLine("Discount Amount: " + discount.ToString("F3") + " OMR");
                Console.WriteLine("Tax Amount: " + tax.ToString("F3") + " OMR");
                Console.WriteLine("Final Total: " + finalTotal.ToString("F3") + " OMR");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 15 - University Admission Decision
            // ==========================================
            Console.WriteLine("========== TASK 15 ==========");

            Console.Write("Enter program type (S for Science, A for Arts): ");
            char programType = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("Enter GPA (out of 4.0): ");
            double gpa = double.Parse(Console.ReadLine());

            Console.Write("Enter entrance exam score (out of 100): ");
            double examScore = double.Parse(Console.ReadLine());

            Console.Write("Do you have extracurricular achievement? (yes/no): ");
            string extracurricularResponse = Console.ReadLine().ToLower();
            bool hasExtracurricular = extracurricularResponse == "yes";

            double minGPA = 0;
            double minExamScore = 0;
            string programName = "";
            bool validProgram = true;

            switch (programType)
            {
                case 'S':
                    programName = "Science";
                    minGPA = 3.0;
                    minExamScore = 75;
                    break;
                case 'A':
                    programName = "Arts";
                    minGPA = 2.5;
                    minExamScore = 60;
                    break;
                default:
                    Console.WriteLine("Invalid program type");
                    validProgram = false;
                    break;
            }

            if (validProgram)
            {
                bool meetsRequirements = gpa >= minGPA && examScore >= minExamScore;
                string admissionStatus;

                if (meetsRequirements)
                {
                    admissionStatus = "Admitted";
                }
                else if (hasExtracurricular)
                {
                    admissionStatus = "Conditionally Admitted";
                }
                else
                {
                    admissionStatus = "Not Admitted";
                }

                Console.WriteLine("Program: " + programName);
                Console.WriteLine("Status: " + admissionStatus);
            }
            Console.WriteLine();

            // End of all tasks
            Console.WriteLine("========== ALL TASKS COMPLETED ==========");
        }
    }
}