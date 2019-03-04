using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public static class WithdrawRulesFactory

    {
        public static IWithdraw Create(AccountType type)
        {

            switch (type)
            {
                case AccountType.Free:
                    FreeAccountWithdrawRule freeRule = new FreeAccountWithdrawRule();
                    return freeRule;
                    break;
                case AccountType.Basic:
                    BasicAccountWithdrawRule basicRule = new BasicAccountWithdrawRule();
                    return basicRule;
                    break;
                case AccountType.Premium:
                    PremiumAccountWithdrawRule premiumRule = new PremiumAccountWithdrawRule();
                    return premiumRule;
                    break;
                default:
                    throw new Exception("Account type is not supported.");
                    break;
            }
        }

    }
}
    

