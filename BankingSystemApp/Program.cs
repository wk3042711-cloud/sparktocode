using System;
using System.Collections.Generic;

namespace BankingSystemApp
{
    internal class Program
    {
        // Shared data storage - declared at class level (static)
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();

        static void Main(string[] args)
        {
            bool exitApp = false;

            // Add some sample accounts for testing
            customerNames.Add("Ahmed");
            accountNumbers.Add("SA001");
            balances.Add(1000.000);

            customerNames.Add("Sara");
            accountNumbers.Add("SA002");
            balances.Add(500.000);

            customerNames.Add("Mohammed");
            accountNumbers.Add("SA003");
            balances.Add(1500.000);

            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. List All Accounts");
                Console.WriteLine("7. Find Richest Customer");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ListAllAccounts();
                        break;
                    case 7:
                        FindRichestCustomer();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }

        // ==========================================
        // SERVICE 1 - Add New Account
        // ==========================================
        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new account number: ");
            string accountNumber = Console.ReadLine();

            // Check if account number already exists
            bool accountExists = false;
            foreach (string acc in accountNumbers)
            {
                if (acc == accountNumber)
                {
                    accountExists = true;
                    break;
                }
            }

            if (accountExists)
            {
                Console.WriteLine("Error: Account number already exists!");
                return;
            }

            Console.Write("Enter initial deposit amount (OMR): ");
            double initialDeposit;
            try
            {
                initialDeposit = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered!");
                return;
            }

            if (initialDeposit < 0)
            {
                Console.WriteLine("Error: Initial deposit cannot be negative!");
                return;
            }

            // Add to all three lists
            customerNames.Add(name);
            accountNumbers.Add(accountNumber);
            balances.Add(initialDeposit);

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Customer: " + name);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Opening Balance: " + initialDeposit.ToString("F3") + " OMR");
        }

        // ==========================================
        // SERVICE 2 - Deposit Money
        // ==========================================
        static void DepositMoney()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == accountNumber)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found!");
                return;
            }

            Console.Write("Enter deposit amount (OMR): ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered!");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be positive!");
                return;
            }

            balances[index] = balances[index] + amount;

            Console.WriteLine("Deposit successful!");
            Console.WriteLine("New balance: " + balances[index].ToString("F3") + " OMR");
        }

        // ==========================================
        // SERVICE 3 - Withdraw Money
        // ==========================================
        static void WithdrawMoney()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == accountNumber)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found!");
                return;
            }

            Console.Write("Enter withdrawal amount (OMR): ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered!");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be positive!");
                return;
            }

            if (amount > balances[index])
            {
                Console.WriteLine("Error: Insufficient balance!");
                Console.WriteLine("Current balance: " + balances[index].ToString("F3") + " OMR");
                return;
            }

            balances[index] = balances[index] - amount;

            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine("New balance: " + balances[index].ToString("F3") + " OMR");
        }

        // ==========================================
        // SERVICE 4 - Show Balance
        // ==========================================
        static void ShowBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == accountNumber)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found!");
                return;
            }

            Console.WriteLine("===== ACCOUNT DETAILS =====");
            Console.WriteLine("Customer Name: " + customerNames[index]);
            Console.WriteLine("Account Number: " + accountNumbers[index]);
            Console.WriteLine("Current Balance: " + balances[index].ToString("F3") + " OMR");
        }

        // ==========================================
        // SERVICE 5 - Transfer Amount
        // ==========================================
        static void TransferAmount()
        {
            Console.Write("Enter sender account number: ");
            string senderAccount = Console.ReadLine();

            int senderIndex = -1;
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == senderAccount)
                {
                    senderIndex = i;
                    break;
                }
            }

            if (senderIndex == -1)
            {
                Console.WriteLine("Error: Sender account not found!");
                return;
            }

            Console.Write("Enter receiver account number: ");
            string receiverAccount = Console.ReadLine();

            int receiverIndex = -1;
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == receiverAccount)
                {
                    receiverIndex = i;
                    break;
                }
            }

            if (receiverIndex == -1)
            {
                Console.WriteLine("Error: Receiver account not found!");
                return;
            }

            if (senderAccount == receiverAccount)
            {
                Console.WriteLine("Error: Cannot transfer to the same account!");
                return;
            }

            Console.Write("Enter transfer amount (OMR): ");
            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered!");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Transfer amount must be positive!");
                return;
            }

            if (amount > balances[senderIndex])
            {
                Console.WriteLine("Error: Insufficient balance in sender account!");
                Console.WriteLine("Current balance: " + balances[senderIndex].ToString("F3") + " OMR");
                return;
            }

            // Perform transfer
            balances[senderIndex] = balances[senderIndex] - amount;
            balances[receiverIndex] = balances[receiverIndex] + amount;

            Console.WriteLine("Transfer successful!");
            Console.WriteLine("Sender (" + customerNames[senderIndex] + "): " + balances[senderIndex].ToString("F3") + " OMR");
            Console.WriteLine("Receiver (" + customerNames[receiverIndex] + "): " + balances[receiverIndex].ToString("F3") + " OMR");
        }

        // ==========================================
        // SERVICE 6 - List All Accounts (Custom Service 1)
        // ==========================================
        static void ListAllAccounts()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("No accounts found in the system!");
                return;
            }

            Console.WriteLine("===== ALL ACCOUNTS =====");
            for (int i = 0; i < customerNames.Count; i++)
            {
                Console.WriteLine("Account " + (i + 1) + ":");
                Console.WriteLine("  Customer: " + customerNames[i]);
                Console.WriteLine("  Account Number: " + accountNumbers[i]);
                Console.WriteLine("  Balance: " + balances[i].ToString("F3") + " OMR");
                Console.WriteLine("------------------------");
            }
            Console.WriteLine("Total accounts: " + customerNames.Count);
        }

        // ==========================================
        // SERVICE 7 - Find Richest Customer (Custom Service 2)
        // ==========================================
        static void FindRichestCustomer()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("No accounts found in the system!");
                return;
            }

            int richestIndex = 0;
            for (int i = 1; i < balances.Count; i++)
            {
                if (balances[i] > balances[richestIndex])
                {
                    richestIndex = i;
                }
            }

            Console.WriteLine("===== RICHEST CUSTOMER =====");
            Console.WriteLine("Customer Name: " + customerNames[richestIndex]);
            Console.WriteLine("Account Number: " + accountNumbers[richestIndex]);
            Console.WriteLine("Balance: " + balances[richestIndex].ToString("F3") + " OMR");

            // Also show all customers sorted by balance (bonus feature)
            Console.WriteLine("\n===== ALL CUSTOMERS BY BALANCE =====");

            // Create a list of indices and sort by balance
            List<int> indices = new List<int>();
            for (int i = 0; i < balances.Count; i++)
            {
                indices.Add(i);
            }

            // Simple bubble sort on indices based on balances
            for (int i = 0; i < indices.Count - 1; i++)
            {
                for (int j = 0; j < indices.Count - i - 1; j++)
                {
                    if (balances[indices[j]] < balances[indices[j + 1]])
                    {
                        int temp = indices[j];
                        indices[j] = indices[j + 1];
                        indices[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < indices.Count; i++)
            {
                int idx = indices[i];
                Console.WriteLine((i + 1) + ". " + customerNames[idx] + " - " + balances[idx].ToString("F3") + " OMR");
            }
        }
    }
}