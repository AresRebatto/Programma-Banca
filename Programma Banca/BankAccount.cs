using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma_Banca
{
    public class BankAccount
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public double Saldo { get; set; }

        public BankAccount(string nome, string cognome, string email, string code, double saldo) 
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Email = email; 
            this.Code = code;
            this.Saldo = saldo;
        }

        public void Deposit(double deposit)
        {
            Saldo = deposit;
        }

        public bool Withdraw(double prelievo)
        {
            if(prelievo <= Saldo)
            {
                return true;
                Saldo -= prelievo;
            }else
            { return false; }
        }
    }
}
