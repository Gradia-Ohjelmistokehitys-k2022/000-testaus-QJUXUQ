using Bank;
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
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);
            

            //Act
            customer.CustomerAccount[0].Debit(debitAmount);

            //Assert
            double actual = customer.CustomerAccount[0].Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() 
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);

            //Act and Assert
            try 
            {
                customer.CustomerAccount[0].Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e) 
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => customer.CustomerAccount[0].Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange() 
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);

            //Act
            try 
            {
                customer.CustomerAccount[0].Debit(debitAmount);
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
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);
            customer.CustomerAccount[0].Credit(creditAmount);
            double actual = customer.CustomerAccount[0].Balance;
            Assert.AreEqual(expected, actual, 0.001);
        }
        [TestMethod]
        public void Credit_IsNotWorking()
        {
            double beginningBalance = 11.99;
            double creditAmount = -20;
            
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);
            try
            {
                customer.CustomerAccount[0].Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expection was not thrown.");
        }

        [TestMethod]
        public void Account_IsRemoved() 
        {
            double beginningBalance = 11.99;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);
            customer.RemoveAccount(0);
            int actual=customer.Accounts.Count();
            int expected=0;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void Account_IsNonExcisting() 
        {
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>customer.RemoveAccount(0));
        }
        
        [TestMethod]
        public void Add_TwoAccounts() 
        {
            double beginningBalance = 11.99;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            customer.AddAccount(beginningBalance);
            customer.AddAccount(beginningBalance);
            int expected = 2;
            int actual= customer.Accounts.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Transaction_Sucess() 
        {
            double beginningBalance = 11.99;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");
            
            customer.AddAccount(beginningBalance);
            customer.AddAccount(beginningBalance);

            double expectedAmountLeft =10.00;
            double expectedAmountReceived = 13.98;
            double takenAmount = 1.99;
            

            try 
            {
                BankAccount.SendMoney(customer.CustomerAccount[0], customer.CustomerAccount[1], takenAmount);
            } catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, BankAccount.BalanceAmountLessThanNeededMessage);
                return;
            }
            double actual = customer.CustomerAccount[0].Balance;
            double actual2 = customer.CustomerAccount[1].Balance;

            Assert.AreEqual(expectedAmountLeft,actual);
            Assert.AreEqual(expectedAmountReceived,actual2);
            
            
        }

        [TestMethod]
        public void Transaction_Fail()
        {
            double beginningBalance = 0.99;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton");

            customer.AddAccount(beginningBalance);
            customer.AddAccount(beginningBalance);

            double takenAmount = 1.99;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => BankAccount.SendMoney(customer.CustomerAccount[0], customer.CustomerAccount[1], takenAmount));
        }

        [TestMethod]

        public void CreatingClient_FromBeginning_ToEnd() 
        {
            //asiakkaiden luonti

            double beginningbalance = 11.99;
            BankCustomer customer = new BankCustomer("Mr. Bryan Walton"); //kaksi uutta asiakasta
            customer.AddAccount(beginningbalance); //yhdell‰ asiakkaalla kolme tili‰
            customer.AddAccount(beginningbalance);
            customer.AddAccount(beginningbalance);
            BankCustomer customer2 = new BankCustomer("Ms. Marge Willow");
            customer2.AddAccount(beginningbalance);

            //tarkistetaan, ett‰ on luotu kolme tili‰ ensimm‰iselle asiakkaalle
            double expected = 3;
            double actual = customer.Accounts.Count();
            Assert.AreEqual(expected, actual);

            //tilin poisto
            customer.RemoveAccount(2); //poistetaan kolmannes tili mik‰ luotiin, j‰‰ kaksi
            actual = customer.Accounts.Count();
            expected = 2;
            Assert.AreEqual(expected, actual);

            //debitin toiminta
            double debitAmount = 4.55;
            expected = 7.44;
            customer.CustomerAccount[0].Debit(debitAmount);
            actual = customer.CustomerAccount[0].Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            
            //debit on v‰hemm‰n kuin 0

            debitAmount = -100.00;
            try
            {
                customer.CustomerAccount[0].Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                
            }
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => customer.CustomerAccount[0].Debit(debitAmount));

            //debit enemm‰n kuin saatavilla
            debitAmount = 20.00;
            try
            {
                customer.CustomerAccount[0].Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                
            }

            //Creditin toiminta:

            //k‰ytet‰‰n toista asiakasta ja h‰nen yht‰ tili‰‰n

            double creditAmount = 20;
            expected = 31.99;
            customer2.CustomerAccount[0].Credit(creditAmount);
            actual = customer2.CustomerAccount[0].Balance;
            Assert.AreEqual(expected, actual, 0.001);

            //Credit v‰hemm‰n kuin nolla
            creditAmount = -20;
            try
            {
                customer2.CustomerAccount[0].Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                
            }
            

            //Tili‰ ei ole olemassa

            BankCustomer customer3 = new BankCustomer("Mr. Broke");
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => customer3.RemoveAccount(0));


            //Transaction:
            //tilien tiedot: ensimm‰isell‰ asiakkaalla on ensimm‰isell‰ tilill‰ 7.44, toisessa 1.99, toisella asiakkaalla ainoalla tilill‰ 31.99
            //l‰hetet‰‰n rahaa asiakkaalta toiselle
            double expectedAmountLeft = 6.44;
            double expectedAmountReceived = 32.99;
            double takenAmount = 1.00;


            try
            {
                BankAccount.SendMoney(customer.CustomerAccount[0], customer2.CustomerAccount[0], takenAmount);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, BankAccount.BalanceAmountLessThanNeededMessage);
                
            }
            actual = customer.CustomerAccount[0].Balance;
            double actual2 = customer2.CustomerAccount[0].Balance;

            Assert.AreEqual(expectedAmountLeft, actual);
            Assert.AreEqual(expectedAmountReceived, actual2);

            //Transaction fail
            

             takenAmount = 20;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => BankAccount.SendMoney(customer.CustomerAccount[0], customer.CustomerAccount[1], takenAmount));



        }


        }
    }
