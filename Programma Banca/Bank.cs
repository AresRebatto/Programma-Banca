using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma_Banca
{
    class Bank
    {
        public List<BankAccount> Account { get; set; } = new List<BankAccount>();

        public void OpenAccount(string nome, string cognome, string email, string code)
        {
            BankAccount newAccount = new BankAccount(nome, cognome, email, code);
            Account.Add(newAccount);
        }
    }
}
