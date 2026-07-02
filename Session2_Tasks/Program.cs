using System;

namespace Session2_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // TASK 1 - Countdown Timer
            // ==========================================
            Console.WriteLine("========== TASK 1 ==========");

            Console.Write("Enter a starting number: ");
            int startNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Liftoff!");
            Console.WriteLine();

            // ==========================================
            // TASK 2 - Sum of Numbers 1 to N
            // ==========================================
            Console.WriteLine("========== TASK 2 ==========");

            Console.Write("Enter a positive whole number N: ");
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine("Sum of numbers from 1 to " + n + " is: " + sum);
            Console.WriteLine();

            // ==========================================
            // TASK 3 - Multiplication Table
            // ==========================================
            Console.WriteLine("========== TASK 3 ==========");

            Console.Write("Enter a number: ");
            int tableNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int product = tableNumber * i;
                Console.WriteLine(tableNumber + " x " + i + " = " + product);
            }
            Console.WriteLine();

            // ==========================================
            // TASK 4 - Password Retry
            // ==========================================
            Console.WriteLine("========== TASK 4 ==========");

            string correctPassword = "Spark2026";
            string userPassword = "";

            while (userPassword != correctPassword)
            {
                Console.Write("Enter the password: ");
                userPassword = Console.ReadLine();

                if (userPassword != correctPassword)
                {
                    Console.WriteLine("Incorrect password, try again");
                }
            }
            Console.WriteLine("Access Granted");
            Console.WriteLine();

            // ==========================================
            // TASK 5 - Number Guessing Game
            // ==========================================
            Console.WriteLine("========== TASK 5 ==========");

            int secretNumber = 42;
            int guess = 0;
            int attempts = 0;

            do
            {
                Console.Write("Guess the secret number: ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess > secretNumber)
                {
                    Console.WriteLine("Too high");
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Too low");
                }
                else
                {
                    Console.WriteLine("Correct! You took " + attempts + " attempts.");
                }
            } while (guess != secretNumber);
            Console.WriteLine();

            // ==========================================
            // TASK 6 - Safe Division Calculator
            // ==========================================
            Console.WriteLine("========== TASK 6 ==========");

            try
            {
                Console.Write("Enter first number: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = double.Parse(Console.ReadLine());

                double divisionResult = num1 / num2;
                Console.WriteLine("Result: " + divisionResult);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: An unexpected error occurred!");
            }
            Console.WriteLine();

            // ==========================================
            // TASK 7 - Repeating Menu with Exit Option
            // ==========================================
            Console.WriteLine("========== TASK 7 ==========");

            int menuChoice = 0;
            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1) Say Hello");
                Console.WriteLine("2) Show Current Time-of-Day Greeting");
                Console.WriteLine("3) Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    menuChoice = int.Parse(Console.ReadLine());

                    switch (menuChoice)
                    {
                        case 1:
                            Console.WriteLine("Hello!");
                            break;
                        case 2:
                            Console.WriteLine("Good day to you!");
                            break;
                        case 3:
                            Console.WriteLine("Exiting...");
                            exitMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number (1, 2, or 3)!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: An unexpected error occurred!");
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            // ==========================================
            // TASK 8 - Sum of Even Numbers Only
            // ==========================================
            Console.WriteLine("========== TASK 8 ==========");

            Console.Write("Enter a positive whole number N: ");
            int nEven = int.Parse(Console.ReadLine());

            int evenSum = 0;
            for (int i = 1; i <= nEven; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum = evenSum + i;
                }
            }
            Console.WriteLine("Sum of even numbers from 1 to " + nEven + " is: " + evenSum);
            Console.WriteLine();

            // ==========================================
            // TASK 9 - Validated Positive Number Input
            // ==========================================
            Console.WriteLine("========== TASK 9 ==========");

            int validatedNumber = 0;
            bool isValidInput = false;

            do
            {
                Console.Write("Enter a positive whole number: ");

                try
                {
                    validatedNumber = int.Parse(Console.ReadLine());

                    if (validatedNumber <= 0)
                    {
                        Console.WriteLine("Error: Number must be positive!");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid whole number!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: An unexpected error occurred!");
                }

            } while (!isValidInput);

            int finalSum = 0;
            for (int i = 1; i <= validatedNumber; i++)
            {
                finalSum = finalSum + i;
            }
            Console.WriteLine("Sum of numbers from 1 to " + validatedNumber + " is: " + finalSum);
            Console.WriteLine();

            // ==========================================
            // TASK 10 - Simple ATM Simulation
            // ==========================================
            Console.WriteLine("========== TASK 10 ==========");

            int correctPin = 1234;
            int pinAttempts = 0;
            bool pinCorrect = false;
            double balance = 100.000;
            int atmChoice = 0;
            bool exitAtm = false;

            // PIN Entry - 3 attempts
            while (pinAttempts < 3 && !pinCorrect)
            {
                try
                {
                    Console.Write("Enter your PIN: ");
                    int enteredPin = int.Parse(Console.ReadLine());

                    if (enteredPin == correctPin)
                    {
                        pinCorrect = true;
                        Console.WriteLine("PIN accepted!");
                        Console.WriteLine();
                    }
                    else
                    {
                        pinAttempts++;
                        Console.WriteLine("Incorrect PIN. Attempts remaining: " + (3 - pinAttempts));
                    }
                }
                catch (FormatException)
                {
                    pinAttempts++;
                    Console.WriteLine("Invalid input. Attempts remaining: " + (3 - pinAttempts));
                }
                catch (Exception)
                {
                    pinAttempts++;
                    Console.WriteLine("Error occurred. Attempts remaining: " + (3 - pinAttempts));
                }
            }

            if (!pinCorrect)
            {
                Console.WriteLine("Card Blocked");
            }
            else
            {
                // ATM Menu
                while (!exitAtm)
                {
                    Console.WriteLine("===== ATM MENU =====");
                    Console.WriteLine("1) Deposit");
                    Console.WriteLine("2) Withdraw");
                    Console.WriteLine("3) Check Balance");
                    Console.WriteLine("4) Exit");
                    Console.Write("Enter your choice: ");

                    try
                    {
                        atmChoice = int.Parse(Console.ReadLine());

                        switch (atmChoice)
                        {
                            case 1: // Deposit
                                try
                                {
                                    Console.Write("Enter amount to deposit: ");
                                    double depositAmount = double.Parse(Console.ReadLine());

                                    if (depositAmount <= 0)
                                    {
                                        Console.WriteLine("Error: Amount must be positive!");
                                    }
                                    else
                                    {
                                        balance = balance + depositAmount;
                                        Console.WriteLine("Deposit successful! New balance: " + balance.ToString("F3") + " OMR");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter a valid number!");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Error: An unexpected error occurred!");
                                }
                                break;

                            case 2: // Withdraw
                                try
                                {
                                    Console.Write("Enter amount to withdraw: ");
                                    double withdrawAmount = double.Parse(Console.ReadLine());

                                    if (withdrawAmount <= 0)
                                    {
                                        Console.WriteLine("Error: Amount must be positive!");
                                    }
                                    else if (withdrawAmount > balance)
                                    {
                                        Console.WriteLine("Error: Insufficient balance!");
                                    }
                                    else
                                    {
                                        balance = balance - withdrawAmount;
                                        Console.WriteLine("Withdrawal successful! New balance: " + balance.ToString("F3") + " OMR");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter a valid number!");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Error: An unexpected error occurred!");
                                }
                                break;

                            case 3: // Check Balance
                                Console.WriteLine("Current balance: " + balance.ToString("F3") + " OMR");
                                break;

                            case 4: // Exit
                                Console.WriteLine("Thank you for using the ATM. Goodbye!");
                                exitAtm = true;
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a number (1, 2, 3, or 4)!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error: An unexpected error occurred!");
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            // End of all tasks
            Console.WriteLine("========== ALL TASKS COMPLETED ==========");
        }
    }
}