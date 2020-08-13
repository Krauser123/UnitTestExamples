using System;

namespace NationalBank
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "The quantity to deposit should be more than zero");
            }

            m_balance += amount;
        }

        public void Withdrawal(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", "You cannot withdraw more money than you have in your account");
            }

            m_balance -= amount;
        }                
    }
}