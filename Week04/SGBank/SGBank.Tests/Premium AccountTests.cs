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
    public class PremiumAccountTests
    {
        [TestCase("44444", "Premium Account", 100, AccountType.Free, 250, false)]
        //4a -- expects fail due to wrong acct type

        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -100, false)]
        //4b -- expects fail due to negative number deposited

        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 250, true)]
        //4c -- success

        public void PremiumAccountDepositRuleTest
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
        ////
        ///Comment3ed out the test below because premium can withdraw any amount.
        //[TestCase("44444", "Premium Account", 1500, AccountType.Premium, -2001, 1500, false)]
        //2a -- expects fail, too much withdrawn

        [TestCase("44444", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        //2b -- expects fail due to not a Premium account type

        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        //2c -- expects fail, positive number withdrawn

        [TestCase("44444", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        //2d -- true

        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -150, -60, true)]
        //2e -- success with overdraft fee

        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw PremiumWithdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = PremiumWithdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }
    }
}


