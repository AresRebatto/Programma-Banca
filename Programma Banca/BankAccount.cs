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
        public bool Transazione { get; set; } = false;
        private int creazioneAnno;
        int tempoAccount;

        public BankAccount(string nome, string cognome, string email, string code, double saldo) 
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Email = email; 
            this.Code = code;
            this.Saldo = saldo;
            DateTime creazione = DateTime.Now;
            creazioneAnno = creazione.Year;
            tempoAccount = 0;
        }

        public double Reload(Bank banca)
        {
            //Calcolo degli interessi
            DateTime now = DateTime.Now;
            int nowYear = now.Year;
            int time = nowYear - creazioneAnno - tempoAccount;
            for(int i = 0; i < time; i++)
            {
                Saldo = Saldo + Saldo / 100; //Un tasso d'interesse dell'1%
            }
            tempoAccount += time;

            //Calcolo saldo tutti gli account
            double saldoTotale = 0;
            foreach(BankAccount users in banca.Account)
            {
                saldoTotale += users.Saldo;
            }

            return saldoTotale;
        }
        public void Deposit(double deposit)
        {
            Saldo += deposit;
        }

        public void Withdraw(double prelievo)
        {
            Saldo -= prelievo;
        }

        public void Send(double somma, Bank banca, string ricevente)
        {
            foreach(BankAccount utenti in banca.Account)
            {
                if(utenti.Nome == ricevente)
                {
                    utenti.Deposit(somma);
                    Saldo -= somma;
                }
            }
        }
    }
}
