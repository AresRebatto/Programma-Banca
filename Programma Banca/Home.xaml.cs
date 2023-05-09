using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma_Banca;

public partial class Home : ContentPage
{
    string name;
    string surname;
    string userCode;
    double saldo;
    
    //Sign-up constructor
    public Home(BankAccount account, string code)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        userCode = code;
        saldo = account.Saldo;
        NewPage();

    }
    
    //log-in constructor
    public Home(BankAccount account)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        NewPage();

    }

    private async void NewPage()
    {
        //Visualizza il nome e cognome nella sezione del profilo
        user.Text = $"{name} {surname}";
        SaldoAccount.Text = $"{saldo}€";
        await DisplayAlert("Attenzione", $"Il tuo codice è {userCode}. Segnatelo e NON perderlo", "Ok");
    }

    private void Pagamenti_Clicked(object sender, EventArgs e)
    {

    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }

    private void CloseAccount_Clicked(object sender, EventArgs e)
    {

    }

    private void reload_Clicked(object sender, EventArgs e)
    {

    }

    private void Deposita_Clicked(object sender, EventArgs e)
    {

    }

    private void Preleva_Clicked(object sender, EventArgs e)
    {

    }

    private void InviaSoldi_Clicked(object sender, EventArgs e)
    {

    }
}