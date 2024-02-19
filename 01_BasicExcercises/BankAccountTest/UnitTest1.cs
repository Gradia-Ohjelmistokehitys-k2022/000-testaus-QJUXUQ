using BankAccountNS;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() 
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //Act and Assert
            try 
            {
                account.Debit(debitAmount);
            }catch (System.ArgumentOutOfRangeException e) 
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange() 
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //Act
            try 
            {
                account.Debit(debitAmount);
            } catch (System.ArgumentOutOfRangeException e) 
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expection was not thrown.");
            
        }

        [TestMethod]
        public void Credit_IsWorking() 
        {
            double beginningBalance = 11.99;
            double creditAmount = 20;
            double expected =31.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton",beginningBalance);
            account.Credit(creditAmount);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001);
        }


    }
    }
