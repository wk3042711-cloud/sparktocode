using System;

namespace oop1
{
    // ==========================================
    // BANK ACCOUNT CLASS
    // ==========================================
    class BankAccount
    {
        // Properties
        public int AccountNumber;
        public string HolderName;
        public double Balance;

        // Constructor
        public BankAccount(int accountNumber, string holderName, double balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }

        // Methods
        public void Deposit(double amount)
        {
            Balance = Balance + amount;
            SendEmail();
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance = Balance - amount;
                SendEmail();
            }
            else
            {
                Console.WriteLine("Error: Insufficient balance!");
            }
        }

        public double CheckBalance()
        {
            PrintInformation();
            return Balance;
        }

        private void PrintInformation()
        {
            Console.WriteLine("Holder Name: " + HolderName);
            Console.WriteLine("Balance: " + Balance.ToString("F3") + " OMR");
        }

        private void SendEmail()
        {
            // Placeholder for email notification
            // No real logic required
        }
    }

    // ==========================================
    // STUDENT CLASS
    // ==========================================
    class Student
    {
        // Properties
        public int Grade;
        public string Name;
        public string Address;

        // Private fields
        private string email;
        private int age; // default access = private

        public void Register(string Email)
        {
            email = Email;
            SendEmail();
        }

        private void SendEmail()
        {
            // Placeholder for registration email
            // No real logic required
        }
    }

    // ==========================================
    // PRODUCT CLASS
    // ==========================================
    class Product
    {
        // Properties
        public string ProductName;
        public double Price;
        public int StockQuantity;

        // Constructor
        public Product(string productName, double price, int stockQuantity)
        {
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void Sell(int quantity)
        {
            if (StockQuantity >= quantity)
            {
                StockQuantity = StockQuantity - quantity;
                LogTransaction();
            }
            else
            {
                Console.WriteLine("Error: Not enough stock available!");
            }
        }

        public void Restock(int quantity)
        {
            StockQuantity = StockQuantity + quantity;
            LogTransaction();
        }

        public double GetInventoryValue()
        {
            PrintDetails();
            return Price * StockQuantity;
        }

        private void PrintDetails()
        {
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Price: " + Price.ToString("F3") + " OMR");
            Console.WriteLine("Stock Quantity: " + StockQuantity);
        }

        private void LogTransaction()
        {
            // Placeholder for transaction logging
            // No real logic required
        }
    }

    // ==========================================
    // PROGRAM CLASS
    // ==========================================
    class Program
    {
        // Create exactly two BankAccount objects
        static BankAccount account1 = new BankAccount(1163, "Karim", 120);
        static BankAccount account2 = new BankAccount(15203, "Ali", 63);

        // Create exactly two Student objects
        static Student student1 = new Student();
        static Student student2 = new Student();

        // Create exactly two Product objects
        static Product product1 = new Product("Wireless Mouse", 5.500, 50);
        static Product product2 = new Product("Mechanical Keyboard", 15.750, 20);

        static void Main(string[] args)
        {
            // Initialize student data
            student1.Name = "Ali";
            student1.Address = "Muscat";
            student1.Grade = 65;

            student2.Name = "Ahmed";
            student2.Address = "Muscat";
            student2.Grade = 70;

            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== OOP BANK & STUDENT MANAGEMENT =====");
                Console.WriteLine("1. View Account Details");
                Console.WriteLine("2. Update Student Address");
                Console.WriteLine("3. Make a Deposit");
                Console.WriteLine("4. Make a Withdrawal");
                Console.WriteLine("5. View Product Details");
                Console.WriteLine("6. Register a Student");
                Console.WriteLine("7. Compare Two Account Balances");
                Console.WriteLine("8. Restock Product & Stock Level Check");
                Console.WriteLine("9. Transfer Between Accounts");
                Console.WriteLine("10. Update Student Grade (Validated)");
                Console.WriteLine("11. Student Report Card");
                Console.WriteLine("12. Account Health Status");
                Console.WriteLine("13. Bulk Sale With Revenue Calculation");
                Console.WriteLine("14. Scholarship Eligibility Check");
                Console.WriteLine("15. Full Balance Top-Up Flow");
                Console.WriteLine("16. Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 16.");
                    continue;
                }

                switch (choice)
                {
                    case 1: ViewAccountDetails(); break;
                    case 2: UpdateStudentAddress(); break;
                    case 3: MakeDeposit(); break;
                    case 4: MakeWithdrawal(); break;
                    case 5: ViewProductDetails(); break;
                    case 6: RegisterStudent(); break;
                    case 7: CompareAccountBalances(); break;
                    case 8: RestockProduct(); break;
                    case 9: TransferBetweenAccounts(); break;
                    case 10: UpdateStudentGrade(); break;
                    case 11: StudentReportCard(); break;
                    case 12: AccountHealthStatus(); break;
                    case 13: BulkSale(); break;
                    case 14: ScholarshipEligibility(); break;
                    case 15: FullBalanceTopUp(); break;
                    case 16:
                        exitApp = true;
                        Console.WriteLine("Thank you! Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 16.");
                        break;
                }
            }
        }

        // ==========================================
        // CASE 1 - View Account Details
        // ==========================================
        static void ViewAccountDetails()
        {
            BankAccount acc = SelectAccount();
            if (acc != null)
            {
                acc.CheckBalance();
            }
        }

        // ==========================================
        // CASE 2 - Update Student Address
        // ==========================================
        static void UpdateStudentAddress()
        {
            Student student = SelectStudent();
            if (student != null)
            {
                Console.Write("Enter new address: ");
                string newAddress = Console.ReadLine();
                student.Address = newAddress;
                Console.WriteLine("Address updated successfully!");
                Console.WriteLine("New address: " + student.Address);
            }
        }

        // ==========================================
        // CASE 3 - Make a Deposit
        // ==========================================
        static void MakeDeposit()
        {
            BankAccount acc = SelectAccount();
            if (acc != null)
            {
                Console.Write("Enter amount to deposit: ");
                try
                {
                    double amount = double.Parse(Console.ReadLine());
                    if (amount <= 0)
                    {
                        Console.WriteLine("Error: Amount must be positive!");
                        return;
                    }
                    acc.Deposit(amount);
                    Console.WriteLine("Deposit successful!");
                    Console.WriteLine("Holder: " + acc.HolderName);
                    Console.WriteLine("New balance: " + acc.Balance.ToString("F3") + " OMR");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid amount entered!");
                }
            }
        }

        // ==========================================
        // CASE 4 - Make a Withdrawal
        // ==========================================
        static void MakeWithdrawal()
        {
            BankAccount acc = SelectAccount();
            if (acc != null)
            {
                Console.Write("Enter amount to withdraw: ");
                try
                {
                    double amount = double.Parse(Console.ReadLine());
                    if (amount <= 0)
                    {
                        Console.WriteLine("Error: Amount must be positive!");
                        return;
                    }
                    acc.Withdraw(amount);
                    Console.WriteLine("New balance: " + acc.Balance.ToString("F3") + " OMR");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid amount entered!");
                }
            }
        }

        // ==========================================
        // CASE 5 - View Product Details
        // ==========================================
        static void ViewProductDetails()
        {
            Product product = SelectProduct();
            if (product != null)
            {
                double inventoryValue = product.GetInventoryValue();
                Console.WriteLine("Total Inventory Value: " + inventoryValue.ToString("F3") + " OMR");
            }
        }

        // ==========================================
        // CASE 6 - Register a Student
        // ==========================================
        static void RegisterStudent()
        {
            Student student = SelectStudent();
            if (student != null)
            {
                Console.Write("Enter email address: ");
                string email = Console.ReadLine();
                student.Register(email);
                Console.WriteLine("Student registered successfully!");
                // Email is private - never printed
            }
        }

        // ==========================================
        // CASE 7 - Compare Two Account Balances
        // ==========================================
        static void CompareAccountBalances()
        {
            Console.WriteLine("Account 1: " + account1.HolderName + " - Balance: " + account1.Balance.ToString("F3"));
            Console.WriteLine("Account 2: " + account2.HolderName + " - Balance: " + account2.Balance.ToString("F3"));

            if (account1.Balance > account2.Balance)
            {
                Console.WriteLine(account1.HolderName + " has more money.");
            }
            else if (account2.Balance > account1.Balance)
            {
                Console.WriteLine(account2.HolderName + " has more money.");
            }
            else
            {
                Console.WriteLine("Both accounts have equal balances.");
            }
        }

        // ==========================================
        // CASE 8 - Restock Product & Stock Level Check
        // ==========================================
        static void RestockProduct()
        {
            Product product = SelectProduct();
            if (product != null)
            {
                Console.Write("Enter quantity to restock: ");
                try
                {
                    int quantity = int.Parse(Console.ReadLine());
                    if (quantity <= 0)
                    {
                        Console.WriteLine("Error: Quantity must be positive!");
                        return;
                    }
                    product.Restock(quantity);
                    Console.WriteLine("Restock successful!");
                    Console.WriteLine("New stock quantity: " + product.StockQuantity);

                    // Stock level check
                    if (product.StockQuantity < 10)
                    {
                        Console.WriteLine("Stock Level: Low (below 10)");
                    }
                    else if (product.StockQuantity >= 10 && product.StockQuantity <= 49)
                    {
                        Console.WriteLine("Stock Level: Moderate (10 to 49)");
                    }
                    else
                    {
                        Console.WriteLine("Stock Level: Well Stocked (50 or above)");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid quantity entered!");
                }
            }
        }

        // ==========================================
        // CASE 9 - Transfer Between Accounts
        // ==========================================
        static void TransferBetweenAccounts()
        {
            Console.WriteLine("=== Select Source Account ===");
            BankAccount source = SelectAccount();
            if (source == null) return;

            Console.WriteLine("=== Select Destination Account ===");
            BankAccount destination = SelectAccount();
            if (destination == null) return;

            if (source == destination)
            {
                Console.WriteLine("Error: Cannot transfer to the same account!");
                return;
            }

            Console.Write("Enter amount to transfer: ");
            try
            {
                double amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Error: Amount must be positive!");
                    return;
                }

                if (source.Balance >= amount)
                {
                    source.Withdraw(amount);
                    destination.Deposit(amount);
                    Console.WriteLine("Transfer successful!");
                    Console.WriteLine("Source balance: " + source.Balance.ToString("F3") + " OMR");
                    Console.WriteLine("Destination balance: " + destination.Balance.ToString("F3") + " OMR");
                }
                else
                {
                    Console.WriteLine("Error: Insufficient balance in source account!");
                    Console.WriteLine("Source balance: " + source.Balance.ToString("F3") + " OMR");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered!");
            }
        }

        // ==========================================
        // CASE 10 - Update Student Grade (Validated)
        // ==========================================
        static void UpdateStudentGrade()
        {
            Student student = SelectStudent();
            if (student != null)
            {
                Console.Write("Enter new grade (0-100): ");
                try
                {
                    int grade = int.Parse(Console.ReadLine());
                    if (grade >= 0 && grade <= 100)
                    {
                        student.Grade = grade;
                        Console.WriteLine("Grade updated successfully!");
                        Console.WriteLine("New grade: " + student.Grade);
                    }
                    else
                    {
                        Console.WriteLine("Error: Grade must be between 0 and 100!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid input! Please enter a number.");
                }
            }
        }

        // ==========================================
        // CASE 11 - Student Report Card
        // ==========================================
        static void StudentReportCard()
        {
            Student student = SelectStudent();
            if (student != null)
            {
                Console.WriteLine("===== REPORT CARD =====");
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Address: " + student.Address);
                Console.WriteLine("Grade: " + student.Grade);
                if (student.Grade >= 60)
                {
                    Console.WriteLine("Status: Pass");
                }
                else
                {
                    Console.WriteLine("Status: Fail");
                }
            }
        }

        // ==========================================
        // CASE 12 - Account Health Status
        // ==========================================
        static void AccountHealthStatus()
        {
            BankAccount acc = SelectAccount();
            if (acc != null)
            {
                Console.WriteLine("Balance: " + acc.Balance.ToString("F3") + " OMR");
                if (acc.Balance < 50)
                {
                    Console.WriteLine("Status: Low Balance");
                }
                else if (acc.Balance >= 50 && acc.Balance <= 1000)
                {
                    Console.WriteLine("Status: Healthy");
                }
                else
                {
                    Console.WriteLine("Status: Premium");
                }
            }
        }

        // ==========================================
        // CASE 13 - Bulk Sale With Revenue Calculation
        // ==========================================
        static void BulkSale()
        {
            Product product = SelectProduct();
            if (product != null)
            {
                Console.Write("Enter quantity to sell: ");
                try
                {
                    int quantity = int.Parse(Console.ReadLine());
                    if (quantity <= 0)
                    {
                        Console.WriteLine("Error: Quantity must be positive!");
                        return;
                    }

                    if (product.StockQuantity >= quantity)
                    {
                        product.Sell(quantity);
                        double revenue = quantity * product.Price;
                        Console.WriteLine("Sale successful!");
                        Console.WriteLine("Quantity sold: " + quantity);
                        Console.WriteLine("Revenue: " + revenue.ToString("F3") + " OMR");
                        Console.WriteLine("Remaining stock: " + product.StockQuantity);
                    }
                    else
                    {
                        int needed = quantity - product.StockQuantity;
                        Console.WriteLine("Error: Not enough stock!");
                        Console.WriteLine("Additional units needed: " + needed);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid quantity entered!");
                }
            }
        }

        // ==========================================
        // CASE 14 - Scholarship Eligibility Check
        // ==========================================
        static void ScholarshipEligibility()
        {
            Console.WriteLine("=== Select Student ===");
            Student student = SelectStudent();
            if (student == null) return;

            Console.WriteLine("=== Select Bank Account ===");
            BankAccount acc = SelectAccount();
            if (acc == null) return;

            bool gradeEligible = student.Grade >= 80;
            bool balanceEligible = acc.Balance >= 100;

            if (gradeEligible && balanceEligible)
            {
                Console.WriteLine("Eligible");
            }
            else
            {
                Console.WriteLine("Not Eligible");
                if (!gradeEligible)
                {
                    Console.WriteLine("Reason: Student grade is " + student.Grade + " (minimum 80 required)");
                }
                if (!balanceEligible)
                {
                    Console.WriteLine("Reason: Account balance is " + acc.Balance.ToString("F3") + " OMR (minimum 100 required)");
                }
            }
        }

        // ==========================================
        // CASE 15 - Full Balance Top-Up Flow
        // ==========================================
        static void FullBalanceTopUp()
        {
            BankAccount acc = SelectAccount();
            if (acc != null)
            {
                double beforeBalance = acc.Balance;
                Console.WriteLine("Current balance: " + beforeBalance.ToString("F3") + " OMR");

                if (beforeBalance < 50)
                {
                    double topUpAmount = 100 - beforeBalance;
                    acc.Deposit(topUpAmount);
                    Console.WriteLine("Top-up amount: " + topUpAmount.ToString("F3") + " OMR");
                    Console.WriteLine("New balance: " + acc.Balance.ToString("F3") + " OMR");
                }
                else
                {
                    Console.WriteLine("No top-up needed. Balance is already 50 OMR or above.");
                }
            }
        }

        // ==========================================
        // HELPER FUNCTIONS
        // ==========================================

        static BankAccount SelectAccount()
        {
            Console.WriteLine("Select an account:");
            Console.WriteLine("1. " + account1.HolderName + " (Account #" + account1.AccountNumber + ")");
            Console.WriteLine("2. " + account2.HolderName + " (Account #" + account2.AccountNumber + ")");
            Console.Write("Enter choice (1 or 2): ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) return account1;
                else if (choice == 2) return account2;
                else
                {
                    Console.WriteLine("Error: Invalid selection!");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input!");
                return null;
            }
        }

        static Student SelectStudent()
        {
            Console.WriteLine("Select a student:");
            Console.WriteLine("1. " + student1.Name + " (Grade: " + student1.Grade + ")");
            Console.WriteLine("2. " + student2.Name + " (Grade: " + student2.Grade + ")");
            Console.Write("Enter choice (1 or 2): ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) return student1;
                else if (choice == 2) return student2;
                else
                {
                    Console.WriteLine("Error: Invalid selection!");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input!");
                return null;
            }
        }

        static Product SelectProduct()
        {
            Console.WriteLine("Select a product:");
            Console.WriteLine("1. " + product1.ProductName + " (Stock: " + product1.StockQuantity + ")");
            Console.WriteLine("2. " + product2.ProductName + " (Stock: " + product2.StockQuantity + ")");
            Console.Write("Enter choice (1 or 2): ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) return product1;
                else if (choice == 2) return product2;
                else
                {
                    Console.WriteLine("Error: Invalid selection!");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input!");
                return null;
            }
        }
    }
}