using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            decimal amount = 0;
            bool validNum = false;

            Console.Write("Enter an account number: ");

            do
            {
                validNum = decimal.TryParse(Console.ReadLine(), out amount);
                if (!validNum) Console.WriteLine("Please enter a postive number with 5 digits.");
            } while (!validNum);

            string accountNumber = amount.ToString();

            Console.Write("Enter a deposit amount: ");
            //decimal amount = decimal.Parse(Console.ReadLine());
            amount = 0;
            validNum = false;

            do
            {
                validNum = decimal.TryParse(Console.ReadLine(), out amount);
                if (!validNum) Console.WriteLine("Please enter a postive number.");
            } while (!validNum);

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
