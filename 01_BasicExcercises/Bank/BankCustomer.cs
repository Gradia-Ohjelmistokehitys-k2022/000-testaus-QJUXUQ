using BankAccountNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankCustomer
    {
        private readonly string customerName;
        public List<BankAccount> Accounts;
        

        public BankCustomer(string asiakasnimi) 
        {
            customerName = asiakasnimi;
            Accounts = new List<BankAccount>();
            
        }
        public string CustomerName
        {
            get { return customerName; }
        }
        public List<BankAccount> CustomerAccount
        {
            get { return Accounts; }
        }
        public void AddAccount(double money) 
        {
            BankAccount account=new BankAccount(money);
            Accounts.Add(account); 
        }
        public void RemoveAccount(int i) //testaa
        {
            if (i >= 0 && i < Accounts.Count)
            {
                Accounts.RemoveAt(i);
            }
            else 
            {
                throw new ArgumentOutOfRangeException();
            }
            


        }
        

    }
    
}
