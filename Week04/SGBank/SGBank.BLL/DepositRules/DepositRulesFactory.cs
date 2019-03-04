﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositRule();
                    break;
                case AccountType.Basic:
                case AccountType.Premium:
                    return new NoLimitDepositRule();
                    break;
            }

            throw new Exception("Account type is not supported!");
        }
    }
}
