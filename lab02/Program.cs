namespace lab02
{


    public class Program
    {
        public static decimal Balance = 0;

        static void Main(string[] args)
        {
            User_interface();
        }

        public static void User_interface()
        {
            Console.WriteLine("Welcome to the ATM");

            while (true)
            {
                Console.WriteLine("To make transaction please pick a number from 1-4 to choose a service:\n1. View Balance\n2. Withdraw\n3. Deposit\n4. Exit");
                string inputService = Console.ReadLine();
                // int serviceNumber = Convert.ToInt32(inputService);

                switch (inputService)
                {
                    case "1":
                        decimal balance = ViewBalance();
                        Console.WriteLine($"Balance: {balance} jd");
                        break;

                    case "2":
                        if (Balance == 0)
                            Console.WriteLine("Your Balance is 0. You cannot make a withdraw transaction!\n");
                        else
                        {
                            Console.WriteLine("Enter money amount to withdraw:");
                            string input1 = Console.ReadLine();
                            try
                            {
                                decimal withdrawAmount = decimal.Parse(input1);
                                Console.WriteLine($"Balance: {Withdraw(withdrawAmount)} jd");

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter money amount to deposit:");
                        string input = Console.ReadLine();
                        try
                        {
                            decimal depoistAmount = decimal.Parse(input);
                            Console.WriteLine($"Balance: {Deposit(depoistAmount)} jd");

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                        }
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid service number. Please try again.");
                        break;
                }
                if (inputService == "4")
                {
                    Console.WriteLine("Thank you for using my ATM");
                    break;
                }

            }
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }
        public static decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Sorry you can not withdraw amount bigger than your Balance!");
                return Balance;
            }
            else if (amount < 0)
            {
                Console.WriteLine("Invalid withdraw ");
                return Balance;
            }
            else
            {
                Balance -= amount;
                return Balance;
            }
        }

        public static decimal Deposit(decimal amount)
        {

            if (amount < 0)
            {
                Console.WriteLine("the amount to deposit MUST be positive");
                return Balance;
            }
            else
                return Balance += amount;
        }


    }

}