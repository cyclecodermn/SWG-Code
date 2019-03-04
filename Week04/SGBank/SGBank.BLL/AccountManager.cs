using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        public IAccountRepository _accountRepository;

        public  AccountWithdrawResponse Withdraw(string accountNumber, Decimal amount )
        {
            //Set varible to recieve responses from tets, like valid account number.
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            
            //Try loading the account number from the account repo
            response.Account = _accountRepository.LoadAccount(accountNumber);
            if (response.Account==null)            
            {
                // The response is false, meaning that the account passed was not valid.
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";

                //Return and finish this Withdraw routine
                return response;
            }
            else
            {
                //The reponse is valid so record that.
                response.Success = true;
            }

            //Since the response is valid, process the the withdraw
            //
            //Get a withdraw constructor for the account type
            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            //Check if the withdraw passed the rules for the account and for the amount.
            response = withdrawRule.Withdraw(response.Account, amount);
            if(response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;

        }

        /// <summary>
        ///  I added stuff above
        /// </summary>
        /// <param name="accountRepository"></param>

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if(response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }

            return response;
        }
    }
}
