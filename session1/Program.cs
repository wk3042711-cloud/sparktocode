namespace session1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //example of reading input from the user


            Console.Write("Please Enter Your Name: ");
            string userName = Console.ReadLine();

            Console.Write("Please Enter Your Age: ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine("please enter your salary: ");
            float userSalary = float.Parse(Console.ReadLine());


            Console.WriteLine("hello " + userName + " welcome to spark");
            ///////////////////////////////////////////////////////////////////////////////
            ///test for arithmetic operations

            Console.WriteLine("enter first number: ");
            float firstNm = float.Parse(Console.ReadLine());

            Console.WriteLine("enter second number: ");
            float secondNm = float.Parse(Console.ReadLine());


            float additionResult = firstNm + secondNm;
            float subtractionResult = firstNm - secondNm;
            float multiplicationResult = firstNm * secondNm;
            float divisionResult = firstNm / secondNm;
            float reminderResult = firstNm % secondNm;


            Console.WriteLine("Addition result: " + additionResult);
            Console.WriteLine("Subtraction result: " + subtractionResult);
            Console.WriteLine("multiplication result: " + multiplicationResult);
            Console.WriteLine("Division result: " + divisionResult);
            Console.WriteLine("Reminder result: " + reminderResult);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            ///test for if else statement


            Console.WriteLine("Enter your degree: ");
            float degree = float.Parse(Console.ReadLine());

            if (degree >= 0 && degree < 50)
            {
                Console.WriteLine("F");
            }
            else if (degree >= 50 && degree < 60)
            {
                Console.WriteLine("D");
            }
            else if (degree >= 60 && degree < 70)
            {
                Console.WriteLine("C");
            }
            else if (degree >= 70 && degree < 80)
            {
                Console.WriteLine("B");
            }
            else if (degree > 80)
            {

                Console.WriteLine("A");
            }
            else
            {
                Console.WriteLine("you entered a wrong number");
            }

            /////////////////////////////////////////////////////////////
            ///test for switch case

            Console.WriteLine("welcome to main menu:");
            Console.WriteLine("1.ATM");
            Console.WriteLine("2.CDM");
            Console.WriteLine("3.Balance check");

            Console.WriteLine("please choose an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("ATM");
                    break;


                case 2:
                    Console.WriteLine("CDM");
                    break;


                case 3:
                    Console.WriteLine("your balance = ");
                    break;

                default:
                    Console.WriteLine("please choose a correct option");
                    break;
            }

        }
    }
}


