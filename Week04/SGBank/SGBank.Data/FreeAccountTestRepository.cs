using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "12345",
            Type = AccountType.Free
        };

        public Account LoadAccount(string AccountNumber)
        {
            //Task1.1
            //Modify the FreeAccountTestRepository LoadAccount() method to 
            //check that the incoming account number is equal to the account 
            //number of the _account field. Return null if it isn’t.

            if (AccountNumber == _account.AccountNumber)
            { return _account; }
            else
            { return null; }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
