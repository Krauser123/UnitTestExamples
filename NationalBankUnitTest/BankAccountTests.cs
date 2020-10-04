using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalBank;

namespace NationalBankUnitTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Withdrawal_Basic()
        {
            // Arrange
            double beginningBalance = 300;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Paco Palotes", beginningBalance);

            account.Withdrawal(debitAmount);

            // Act and assert
            Assert.AreEqual(200, account.Balance);
        }

        [TestMethod]
        public void Deposit_Basic()
        {
            // Arrange
            double beginningBalance = 0;
            double depositAmount = 200.00;
            BankAccount account = new BankAccount("Mr. Paco Palotes", beginningBalance);

            account.Deposit(depositAmount);

            // Act and assert
            Assert.AreEqual(200, account.Balance);
        }

        [TestMethod, Timeout(50)]
        public void MultipleActionOverAccount()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Paco Palotes", 0);

            int iterationsDeposit = 300;
            int depositValue = 100;
            int iterationsWithdrawal = 300;
            int withdrawalValue = 50;

            for (int i = 0; i < iterationsDeposit; i++)
            {
                account.Deposit(depositValue);
            }

            for (int i = 0; i < iterationsWithdrawal; i++)
            {
                account.Withdrawal(withdrawalValue);
            }

            var expectedBalance = (iterationsDeposit * depositValue) - (iterationsWithdrawal * withdrawalValue);

            // Act and assert
            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod]
        public void Withdrawal_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 20;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Paco Palotes", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Withdrawal(debitAmount));
        }

        [TestMethod]
        public void Deposit_WhenAmountIsZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 20;
            double depositAmount = 0.00;
            BankAccount account = new BankAccount("Mr. Paco Palotes", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Deposit(depositAmount));
        }

        [TestMethod]
        public void Withdrawal_WhenAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 20;
            double debitAmount = 3000.00;
            BankAccount account = new BankAccount("Mr. Paco Palotes", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Withdrawal(debitAmount));
        }

    }
}
