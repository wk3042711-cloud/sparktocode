using System;

namespace session_3_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // TASK 1 - Absolute Difference
            // ==========================================
            Console.WriteLine("========== TASK 1 ==========");

            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            double difference = num1 - num2;
            double absoluteDifference = Math.Abs(difference);

            Console.WriteLine("Absolute difference: " + absoluteDifference);
            Console.WriteLine();

            // ==========================================
            // TASK 2 - Power & Root Explorer
            // ==========================================
            Console.WriteLine("========== TASK 2 ==========");

            Console.Write("Enter a number: ");
            double powerNumber = double.Parse(Console.ReadLine());

            double square = Math.Pow(powerNumber, 2);
            double squareRoot = Math.Sqrt(powerNumber);

            Console.WriteLine("Square (power of 2): " + square);
            Console.WriteLine("Square root: " + squareRoot);
            Console.WriteLine();

            // ==========================================
            // TASK 3 - Name Formatter
            // ==========================================
            Console.WriteLine("========== TASK 3 ==========");

            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            string upperName = fullName.ToUpper();
            string lowerName = fullName.ToLower();
            int nameLength = fullName.Length;

            Console.WriteLine("Uppercase: " + upperName);
            Console.WriteLine("Lowercase: " + lowerName);
            Console.WriteLine("Number of characters: " + nameLength);
            Console.WriteLine();

            // ==========================================
            // TASK 4 - Subscription End Date
            // ==========================================
            Console.WriteLine("========== TASK 4 ==========");

            Console.Write("Enter the number of days of free trial: ");
            int trialDays = int.Parse(Console.ReadLine());

            DateTime endDate = DateTime.Today.AddDays(trialDays);

            Console.WriteLine("Trial ends on: " + endDate.ToString("yyyy-MM-dd"));
            Console.WriteLine();

            // ==========================================
            // TASK 5 - Grade Rounding System
            // ==========================================
            Console.WriteLine("========== TASK 5 ==========");

            Console.Write("Enter your raw exam score (e.g., 74.6): ");
            double rawScore = double.Parse(Console.ReadLine());

            double roundedScore = Math.Round(rawScore, 0);
            string passResult;

            if (roundedScore >= 60)
            {
                passResult = "Pass";
            }
            else
            {
                passResult = "Fail";
            }

            Console.WriteLine("Rounded score: " + roundedScore);
            Console.WriteLine("Result: " + passResult);
            Console.WriteLine();

            // ==========================================
            // TASK 6 - Password Strength Checker
            // ==========================================
            Console.WriteLine("========== TASK 6 ==========");

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            bool isLongEnough = password.Length >= 8;
            bool doesNotContainForbidden = !password.ToLower().Contains("password");

            if (isLongEnough && doesNotContainForbidden)
            {
                Console.WriteLine("Strong");
            }
            else
            {
                Console.Write("Weak - ");
                if (!isLongEnough)
                {
                    Console.Write("Password must be at least 8 characters long. ");
                }
                if (!doesNotContainForbidden)
                {
                    Console.Write("Password cannot contain the word 'password'.");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // ==========================================
            // TASK 7 - Clean Name Comparator
            // ==========================================
            Console.WriteLine("========== TASK 7 ==========");

            Console.Write("Enter the name (first time): ");
            string name1 = Console.ReadLine();

            Console.Write("Enter the same name (second time): ");
            string name2 = Console.ReadLine();

            string cleanName1 = name1.Trim().ToUpper();
            string cleanName2 = name2.Trim().ToUpper();

            if (cleanName1 == cleanName2)
            {
                Console.WriteLine("Match");
            }
            else
            {
                Console.WriteLine("No Match");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 8 - Membership Expiry Checker
            // ==========================================
            Console.WriteLine("========== TASK 8 ==========");

            try
            {
                Console.Write("Enter membership start date (e.g., 2026-01-10): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter number of valid membership days: ");
                int membershipDays = int.Parse(Console.ReadLine());

                DateTime expiryDate = startDate.AddDays(membershipDays);

                if (expiryDate >= DateTime.Today)
                {
                    Console.WriteLine("Active");
                }
                else
                {
                    Console.WriteLine("Expired");
                }
                Console.WriteLine("Expiry date: " + expiryDate.ToString("yyyy-MM-dd"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid date in the format yyyy-MM-dd!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: An unexpected error occurred!");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 9 - Round Up / Round Down Explorer
            // ==========================================
            Console.WriteLine("========== TASK 9 ==========");

            Console.Write("Enter a decimal number: ");
            double decimalNumber = double.Parse(Console.ReadLine());

            double nearestRound = Math.Round(decimalNumber, 0);
            double roundUp = Math.Ceiling(decimalNumber);
            double roundDown = Math.Floor(decimalNumber);

            Console.WriteLine("Nearest whole number: " + nearestRound);
            Console.WriteLine("Always rounded up: " + roundUp);
            Console.WriteLine("Always rounded down: " + roundDown);
            Console.WriteLine();

            // ==========================================
            // TASK 10 - Word Position Finder
            // ==========================================
            Console.WriteLine("========== TASK 10 ==========");

            Console.Write("Enter a full sentence: ");
            string sentence = Console.ReadLine();

            Console.Write("Enter a single word to search for: ");
            string searchWord = Console.ReadLine();

            int firstIndex = sentence.IndexOf(searchWord);
            int lastIndex = sentence.LastIndexOf(searchWord);

            if (firstIndex == -1)
            {
                Console.WriteLine("Word not found");
            }
            else
            {
                Console.WriteLine("First occurrence position: " + firstIndex);
                Console.WriteLine("Last occurrence position: " + lastIndex);
            }
            Console.WriteLine();

            // ==========================================
            // TASK 11 - One-Time Password (OTP) Generator
            // ==========================================
            Console.WriteLine("========== TASK 11 ==========");

            Random random = new Random();
            int otpCode = random.Next(1000, 10000);

            Console.WriteLine("Your OTP code has been sent: " + otpCode);
            Console.WriteLine("(In a real system, this would be sent to your phone/email)");

            int otpAttempts = 0;
            bool otpVerified = false;

            while (otpAttempts < 3 && !otpVerified)
            {
                try
                {
                    Console.Write("Enter the OTP code to verify: ");
                    int enteredOtp = int.Parse(Console.ReadLine());

                    if (enteredOtp == otpCode)
                    {
                        Console.WriteLine("Verified");
                        otpVerified = true;
                    }
                    else
                    {
                        otpAttempts++;
                        Console.WriteLine("Incorrect OTP. Attempts remaining: " + (3 - otpAttempts));
                    }
                }
                catch (FormatException)
                {
                    otpAttempts++;
                    Console.WriteLine("Invalid input. Please enter a number. Attempts remaining: " + (3 - otpAttempts));
                }
                catch (Exception)
                {
                    otpAttempts++;
                    Console.WriteLine("Error occurred. Attempts remaining: " + (3 - otpAttempts));
                }
            }

            if (!otpVerified)
            {
                Console.WriteLine("Verification Failed");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 12 - Birthday Insights
            // ==========================================
            Console.WriteLine("========== TASK 12 ==========");

            try
            {
                Console.Write("Enter your date of birth (e.g., 2000-05-14): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                // Calculate age
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;

                // Check if birthday has occurred this year
                if (birthDate.Month > today.Month ||
                    (birthDate.Month == today.Month && birthDate.Day > today.Day))
                {
                    age = age - 1;
                }

                // Get day of the week
                string birthDayOfWeek = birthDate.DayOfWeek.ToString();

                Console.WriteLine("Age: " + age + " years");
                Console.WriteLine("Day of the week you were born: " + birthDayOfWeek);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid date in the format yyyy-MM-dd!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: An unexpected error occurred!");
            }
            Console.WriteLine();

            // End of all tasks
            Console.WriteLine("========== ALL TASKS COMPLETED ==========");
        }
    }
}