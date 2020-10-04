using System;

namespace NationalBank
{
    public class Cashier
    {
        private BankAccount _bankAccount;

        public Cashier(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                _bankAccount = bankAccount;
            }
            else
            {
                throw new ArgumentNullException("bankAccount");
            }
        }

        public void CashierMainScreen()
        {
            bool stillInMainScreen = true;
            do
            {
                var menuElection = DrawMenuAndReadOption(_bankAccount.CustomerName);
                Console.Clear();
                
                switch (menuElection)
                {
                    case 1:
                        Console.WriteLine("Please enter the amount you want to deposit into the account");
                        if (Double.TryParse(Console.ReadLine(), out double moneyToAdd))
                        {
                            _bankAccount.Deposit(moneyToAdd);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Please enter the amount you want to withdraw from the account");
                        if (Double.TryParse(Console.ReadLine(), out double moneyTowithdraw))
                        {
                            _bankAccount.Withdrawal(moneyTowithdraw);
                        }
                        break;
                    case 3:
                        DrawCashierHeader(_bankAccount.CustomerName);
                        Console.WriteLine($"Current balance is {_bankAccount.Balance}");
                        break;
                    case 4:
                        stillInMainScreen = false;
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.Read();
            } while (stillInMainScreen);
        }

        private void DrawCashierHeader(string customerName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************");
            Console.WriteLine("--- Welcome to National Bank ---");
            Console.WriteLine("********************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"   Customer: {customerName}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Environment.NewLine);
        }

        private int DrawMenuAndReadOption(string customerName)
        {
            int menuElection;

            do
            {
                Console.Clear();
                DrawCashierHeader(customerName);
                Console.WriteLine("What do you want?");

                Console.WriteLine("1- Make a deposit");
                Console.WriteLine("2- Make a withdrawal");
                Console.WriteLine("3- See your account balance");
                Console.WriteLine("4- Exit");
                Console.Write(Environment.NewLine);
                Console.WriteLine("Please, type the number of action that you want to perform.");
            }
            while (!Int32.TryParse(Console.ReadLine(), out menuElection));


            return menuElection;
        }
    }
}
