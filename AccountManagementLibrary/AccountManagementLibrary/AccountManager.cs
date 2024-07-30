using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagementLibrary.ExceptionHandling;

namespace AccountManagementLibrary
{
    public class AccountManager
    {

        public static List<Account> accounts = new List<Account>();

        public static void AddAccount()
        {
            Console.WriteLine("Enter Id : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Bank Name : ");
            string bankName = Console.ReadLine();
            Console.WriteLine("Enter Balance : ");
            double balance = double.Parse(Console.ReadLine());

             accounts.Add(new Account(id, name,bankName, balance));
             Console.WriteLine("Account Created Successfully!!");
        }

        public static void FindAccountById()
        {
            Console.WriteLine("Enter Account Number : ");
            int inputAccountNumber = int.Parse(Console.ReadLine());
            try
            {
                foreach (Account account in accounts)
                {
                    if (account.accountId == inputAccountNumber)
                    {
                        Console.WriteLine(account);
                        break;
                    }
                    else
                    {
                        throw new FindAccountException("Account Not Found");
                    }
                }
            }
            catch (FindAccountException e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public static void DisplayAccounts()
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine(account);
            }
        }
        public static void UpdateAccount()
        {
            Console.WriteLine("Enter Account Number : ");
            int inputAccountNumber1 = int.Parse(Console.ReadLine());
            foreach (Account account in accounts)
            {
                if (account.accountId == inputAccountNumber1)
                {
                    Console.WriteLine("Enter Updated Name : ");
                    string newName = Console.ReadLine();
                    account.accountName = newName;
                    Console.WriteLine(account);
                }
            }
        }

        public static void RemoveAccount()
        {
            Console.WriteLine("Enter Account Number : ");
            int inputAccountNumber1 = int.Parse(Console.ReadLine());
            foreach (Account account in accounts.ToList())
            {
                if (inputAccountNumber1 == account.accountId)
                {
                    accounts.Remove(account);
                    Console.WriteLine("Account Removed Successfully!!");
                }
            }
        }
        public static void ClearAccount()
        {
            Console.WriteLine("All accounts clear");
            accounts.Clear();
        }

        public static void DepositAmount()
        {
            Console.WriteLine("Enter Account Number : ");
            int inputAccountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Amount to be Deposited : ");
            double depositAmount = double.Parse(Console.ReadLine());

            foreach (Account account in accounts)
            {
                if (account.accountId == inputAccountNumber)
                {                    
                    Console.WriteLine("Account Balance : " + account.Deposit(depositAmount));
                }
            }
        }

        public static void WithdrawAmount()
        {
            Console.WriteLine("Enter Account Number : ");
            int inputAccountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Amount to be Withdraw : ");
            double withdrawAmount = double.Parse(Console.ReadLine());

            foreach (Account account in accounts)
            {
                if (account.accountId == inputAccountNumber)
                {
                    Console.WriteLine("Account Balance : " + account.Withdraw(withdrawAmount));                
                }
            }
        }

        public static void SubMenu()
        {
            while (true)
            {
                Console.WriteLine($"1 . Deposit\n" +
                              $"2 . Withdraw\n" +
                              $"3 . Exit\n");

                int userInput2 = int.Parse(Console.ReadLine());

                switch (userInput2)
                {
                    case 1:
                        DepositAmount();
                        break;
                    case 2:
                        WithdrawAmount();
                        break;
                    case 3:
                        return;
                }
            }
        }

        public static void DoTask()
        {
            accounts=SerializeDeserialize.DeserializedData();
            while (true)
            {
                Console.WriteLine("Welcome to Account Management App\n" +
                                  "What do you wish to do ?\n" +
                                  "1 . Create New Account\n" +                                 
                                  "2 . Work With Existing Account\n" +
                                  "3 . Find Account By Id\n" +
                                  "4 . Display All Accounts\n" +
                                  "5 . Update an Account\n" +
                                  "6 . Remove Account By ID\n" +
                                  "7 . Clear All Accounts\n" +
                                  "8 . Exit\n");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddAccount();                                                
                        break;
                    case 2:
                        SubMenu();
                        break;
                    case 3:
                        FindAccountById();
                        break;
                    case 4:
                        DisplayAccounts();
                        break;
                    case 5:
                        UpdateAccount();
                        break;
                    case 6:
                        RemoveAccount();
                        break;
                    case 7:
                        ClearAccount();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }
                SerializeDeserialize.SerializedData(accounts);
            }

        }

    }
}
