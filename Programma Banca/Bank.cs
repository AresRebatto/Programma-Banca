using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma_Banca
{
    class Bank
    {
        public List<BankAccount> Account { get; set; } 
        public BankAccount newAccount { get; set; }
        public void OpenAccount(string nome, string cognome, string email, string code, double saldo)
        {
            newAccount = new BankAccount(nome, cognome, email, code, saldo);
            Account = new List<BankAccount>();
            Account.Add(newAccount);
            
        }

        public bool Transfer(double trasferimento, string userCodeOut)
        {
            bool riuscita = true;
            foreach(BankAccount account in Account)
            {
                if(account.Code == userCodeOut)
                {
                    account.Saldo += trasferimento;
                    riuscita = true;
                    break;
                }else
                {
                    riuscita = false;
                }
            }

            return riuscita;
        }

        public void Close(BankAccount removeAccount)
        {
            Account.Remove(removeAccount);
        }
    }
}
