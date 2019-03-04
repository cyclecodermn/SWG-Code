using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {

        public Account LoadAccount(string AccountNumber)
        {
            List<Account> Accounts = new List<Account>();
            Accounts = ReadFile();
            return Accounts.FirstOrDefault(a=>a.AccountNumber==AccountNumber);
        }

        public void SaveAccount(Account account)
        {
            List<Account> Accounts = new List<Account>();
            Accounts = ReadFile();
            String changedAccountNum = account.AccountNumber;
            int oldAccountIndx = Accounts.FindIndex (a => a.AccountNumber == changedAccountNum);
            Accounts[oldAccountIndx] = account;
            SaveFile(Accounts);
        }

        public static void SaveFile(List<Account> AllAccounts)
        {
            string oneLtrAcctType = "";
            string path = "Accounts.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Account oneAccount in AllAccounts)
                //for (int i = 0; i < 10; i++)
                {

                    writer.Write(oneAccount.AccountNumber+",");            
                    writer.Write(oneAccount.Name + ",");      
                    writer.Write(oneAccount.Balance + ",");
                    oneLtrAcctType = oneAccount.Type.ToString();
                    oneLtrAcctType = oneLtrAcctType.Substring(0, 1);
                    writer.WriteLine(oneLtrAcctType);   
                }
            }
            //Console.WriteLine($"File {path} written.");
            //    Console.ReadLine();
        }


        public static List<Account> ReadFile()
        {
            //C:\Users\steve\source\repos\CRRUD _Weekend_Bike_Routes2\CRRUD _Weekend_Bike_Routes2\DAL

            string line;
            Account oneFileAcct = null;
            List<Account> Accounts = new List<Account>();

            string path = "Accounts.txt";
         
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    oneFileAcct=mapToAccount(line);
                    Accounts.Add(oneFileAcct);
                }
            }
            return Accounts;
            //Console.WriteLine("Press a Enter...");
            //Console.ReadLine();
        }

        private static Account mapToAccount(string line)
        {
            var numStyle = NumberStyles.None;
            string acctType = "";
            string[] fields = line.Split(',');

            Account newAcct = new Account();
            newAcct.AccountNumber = fields[0];
            newAcct.Name = fields[1];

            newAcct.Balance = Decimal.Parse(fields[2]);
            acctType = fields[3].ToUpper();
            switch (acctType)
            {
                case "F":
                    newAcct.Type = AccountType.Free;
                    break;
                case "B":
                    newAcct.Type = AccountType.Basic;
                    break;
                case "P":
                    newAcct.Type = AccountType.Premium;
                    break;
                default:
                    throw new Exception("Account type not found during file read.");
            }
            return newAcct;
        }
    }
}
