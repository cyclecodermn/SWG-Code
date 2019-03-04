using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            //Task 1.3
            //In the CanLoadFreeAccountTestData() method of the FreeAccountTests in 
            //the test project, update the LookupAccount() method call to pass in the 
            // account 12345 as the parameter
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);

            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        //The 4 test cases below are the input for the ** FreeAccountDeposit ** tests.
        //
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        //2a -- expects fail due to too high of a deposit for a free acct

        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        //2b -- expects fail due to negative number deposited

        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        //2c -- expects fail due to not being a free acct type

        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        //2d -- expects true

        public void FreeAccountDepositRuleTest
            (string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
            //                                               expected result is the key outcome
        {
            // Assert.AreEqual(accountNumber, "12345");
            
            IDeposit deposit = new FreeAccountDepositRule();
            //The factory follows IDeposit guidlines, complete the IDeposit contract

            //Note: The lines below do not include amount because accounts are not defined by the deposit amount.
            // ie Amount refers to the deposit rather than the account. And we're testing on free accounts.
            // All the lines below can be copied to all the account tests and the withdraw. These 5 lines 
            //set up an account object.
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            //TODO: Probably need to assign oldBalance below.
            account.Type = accountType;
            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            // Assert is specific to tests. It gives check mark or x
            // for the test.
            //
            //End of Free Account Deposit Tests
            /////////////////////////////////////
        }

        ////////////////////////////////////
        //
        //Test for Free Acct Withdrawl


        //The 4 test cases below are the input for the **Free Account Withdraw** tests.
        //
        [TestCase("12345", "Free Account", 100, AccountType.Free, 11, false)]
        //4bi -- expects fail due to a positive withdrawl amount

        [TestCase("12345", "Free Account", 100, AccountType.Free, -502, false)]
        //4bii -- expects fail due to negative withdrawl over limit

        [TestCase("12345", "Basic Account", 100, AccountType.Basic, -53, false)]
        //4biii -- expects fail due to not being a free acct type

        [TestCase("12345", "Free Account", 80, AccountType.Free, -94, false)]
        //4biv -- expects fail due to overdraft

        [TestCase("12345", "Free Account", 100, AccountType.Free, -15, true)]
        //4bv -- expects true

        public void FreeAccountWithdrawRuleTest
            (string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        //                                               expected result is the key outcome
        {
            // Assert.AreEqual(accountNumber, "12345");

            IWithdraw withdraw = new FreeAccountWithdrawRule();
            //The factory follows IWithdraw guidlines, complete the IWithdraw contract

            //Note: The lines below do not include amount because accounts are not defined by the withdrawl amount.
            // ie Amount refers to the deposit rather than the account. And we're testing on free accounts.
            // All the lines below can be copied to all the account tests and the withdraw. These 5 lines 
            //set up an account object.
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            // Assert is specific to tests. It gives check mark or x
            // for the test.
        }

        //
        // End of Tests for Withdrawl
        ////////////////////////////////////

    }
}
