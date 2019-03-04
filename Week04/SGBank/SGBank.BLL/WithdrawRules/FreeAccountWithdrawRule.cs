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
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            // Example of using an enum
            if (account.Type != AccountType.Free)
            {
                //4b Not a free acct
                response.Success = false;
                response.Message = "A free account is not used.";
                return response;

            }
            if (amount >= 0)
            {
                //4c Non-negative withdrawl
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative.";
                return response;

            }
            if (amount<-100)
            {
                //4d 100 limit on free accts
                response.Success = false;
                response.Message = "Free accounts cannot withdraw more than $100";
                return response;
            }
            if (account.Balance+amount<0)
            {
                //4e Balance < zero
                response.Success = false;
                response.Message = "Free accounts cannot overdraft.";
                return response;
            }
            //Passed all the tests so process the withdrawl

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            return response;
        }
    }
}
