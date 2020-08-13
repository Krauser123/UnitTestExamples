using System;

namespace NationalBank
{
    class BankCashier
    {
        public static void Main()
        {
            BankAccount bankAccount = new BankAccount("Mr. White Danger", 25);

            do
            {
                var menuElection = DrawMenuAndReadOption(bankAccount.CustomerName);

                Console.Clear();
                DrawCashierHeader(bankAccount.CustomerName);

                switch (menuElection)
                {
                    case 1:
                        Console.WriteLine("Please enter the amount you want to deposit into the account");
                        if (Double.TryParse(Console.ReadLine(), out double moneyToAdd))
                        {
                            bankAccount.Deposit(moneyToAdd);
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Please enter the amount you want to withdraw from the account");
                        if (Double.TryParse(Console.ReadLine(), out double moneyTowithdraw))
                        {
                            bankAccount.Withdrawal(moneyTowithdraw);
                        }
                        break;
                    case 3:
                        DrawCashierHeader(bankAccount.CustomerName);
                        Console.WriteLine($"Current balance is {bankAccount.Balance}");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        private static void DrawCashierHeader(string customerName)
        {
            Console.WriteLine("********************************");
            Console.WriteLine("--- Welcome to National Bank ---");
            Console.WriteLine("********************************");

            Console.WriteLine(customerName);
            Console.WriteLine(Environment.NewLine);
        }

        private static int DrawMenuAndReadOption(string customerName)
        {
            int menuElection;

            do
            {
                Console.Clear();
                DrawCashierHeader(customerName);
                Console.WriteLine("What do you want?");

                Console.WriteLine("1- Make a deposit");
                Console.WriteLine("2- Make a withdrawal");
                Console.WriteLine("3- See you account balance");
                Console.WriteLine("4- Exit");

                Console.WriteLine("Please, type the number of action that you want to perform.");
            }
            while (Int32.TryParse(Console.ReadLine(), out menuElection));


            return menuElection;
        }
    }
}
