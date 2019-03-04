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
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            // Example of using an enum
            if (account.Type != AccountType.Premium)
            {
                //4b Not a free acct
                response.Success = false;
                response.Message = "Error: a non-Premium account hit the Premium Withdraw Rule--contact IT.";
                return response;

            }
            if (amount >= 0)
            {
                //4c Non-negative withdrawl
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative.";
                return response;

            }
            // Commented out since this class/rule set was copied from Basic
            // and Premium has no withdrawl limit.
            //if (amount < -500)
            //{
            //    //4d 100 limit on free accts
            //    response.Success = false;
            //    response.Message = "Premium accounts cannot withdraw more than $500";
            //    return response;
            //}
            if (account.Balance + amount < -500)
            {
                //4e Balance < zero
                if (account.Type != AccountType.Premium)
                {

                    response.Success = false;
                    response.Message = "This amount will overdraft more than your $500 limit.";
                    return response;
                }
            }
            //Passed all the tests so process the withdrawl

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            if (account.Balance<-500) { account.Balance -= 10; }
            return response;
        }
    }
}
