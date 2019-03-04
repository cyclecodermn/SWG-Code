using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Tests
{
    [TestFixture]
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        //4a -- expects fail due to wrong acct type

        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -10, false)]
        //4b -- expects fail due to negative number deposited

        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 50, true)]
        //4c -- success

        public void BasicAccountDepositRuleTest
            (string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
               
        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)]
        //2a -- expects fail, too much withdrawn

        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        //2b -- expects fail due to not a basic account type

        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        //2c -- expects fail, positive number withdrawn

        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        //2d -- true

        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]
        //2e -- success with overdraft fee

        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw basicWithdraw = new BasicAccountWithdrawRule();
            Account account = new Account();
            // TODO: Probably need to assign oldbalance below.
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = basicWithdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }
    }
}


