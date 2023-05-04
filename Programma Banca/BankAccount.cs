using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma_Banca
{
    class BankAccount
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }

        public BankAccount(string nome, string cognome, string email, string code) 
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Email = email; 
            this.Code = code;
        }
    }
}
