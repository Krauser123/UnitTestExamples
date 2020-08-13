using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalBank;

namespace NationalBankUnitTest
{
    [TestClass]
    public class BankAccountTests
    {
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
