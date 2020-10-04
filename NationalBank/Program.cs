namespace NationalBank
{
    class BankCashier
    {
        public static void Main()
        {

            BankAccount bankAccount = new BankAccount("Mr. White Danger", 25);
            new Cashier(bankAccount).CashierMainScreen();
        }

    }
}
