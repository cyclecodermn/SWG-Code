using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            // Example of using an enum
            if (account.Type != AccountType.Basic)
            {
                //4b Not a free acct
                response.Success = false;
                response.Message = "Error: a non-basic account hit the Basic Withdraw Rule--contact IT.";
                return response;

            }
            if (amount >= 0)
            {
                //4c Non-negative withdrawl
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative.";
                return response;

            }
            if (amount < -500)
            {
                //4d 100 limit on free accts
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500";
                return response;
            }
            if (account.Balance + amount < -100)
            {
                //4e Balance < zero
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit.";
                return response;
            }
            //Passed all the tests so process the withdrawl

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            if (account.Balance<0) { account.Balance -= 10; }
            return response;
        }
    }
}
