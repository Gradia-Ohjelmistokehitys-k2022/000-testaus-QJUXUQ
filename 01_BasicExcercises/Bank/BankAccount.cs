namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
       
        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string BalanceAmountLessThanNeededMessage = "Bank account does not have enough value for this transaction";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";
        private BankAccount() { }

        public BankAccount(double balance)
        {
            
            m_balance = balance;
        }

       

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount",amount,DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount",amount,DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code CORRECTED
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount",amount,CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        public static void SendMoney(BankAccount sendingAccount,BankAccount receivingAccount, double sendingAmount) 
        {
            if (sendingAccount.m_balance > sendingAmount)
            {
                sendingAccount.m_balance -= sendingAmount;
                receivingAccount.m_balance += sendingAmount;
            }
            else 
            {
                throw new ArgumentOutOfRangeException(BalanceAmountLessThanNeededMessage);
            }
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount( 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

    }
}