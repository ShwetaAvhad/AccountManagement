using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagementLibrary.ExceptionHandling;

namespace AccountManagementLibrary
{
    public class Account
    {

        public int accountId { get; set; }
        public string accountName { get; set; }
        public string accountBankName {  get; set; }
        public double accountBalance { get; set; }

        public const double MIN_BALANCE = 500;

        public Account() { }
        public Account(int id, string name, string accountbankname)
        {
            accountId = id;
            accountName = name;
            accountBankName = accountbankname;
            if (accountBalance < MIN_BALANCE)
            {
                accountBalance = MIN_BALANCE;
            }           
        }
        public Account(int id, string name,string accountbankname, double balance) : this(id, name,accountbankname)
        {
            accountBalance = balance;
            if (balance < MIN_BALANCE)
            {
                accountBalance = MIN_BALANCE;
            }
            else
            {
                accountBalance = balance;
            }
        }
        public double Deposit(double amount)
        {
            double result = accountBalance += amount;
            return result;
        }
        public double Withdraw(double amount)
        {
            double afterWithdrawal = accountBalance - amount;
            try
            {
                if (afterWithdrawal < MIN_BALANCE)
                {
                    
                    throw new WithdrawAmountException("Balance is low");
                    return accountBalance;
                }
                else
                {
                    accountBalance = afterWithdrawal;
                    return accountBalance;
                }
            }
            catch (WithdrawAmountException w)
            {
                Console.WriteLine(w.Message);
                return accountBalance;
            }
        }
        public override string ToString()
        {
            return $"Account Id : {accountId}\n" +
                   $"Account Holder Name : {accountName}\n" +
                   $"Bank Name : {accountBankName}\n" +
                   $"Account Balance : {accountBalance}\n";
        }

    }
}
