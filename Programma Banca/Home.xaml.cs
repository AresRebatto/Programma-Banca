using CommunityToolkit.Maui.Views;
using Microsoft.UI.Xaml.Controls.Primitives;
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
    BankAccount currentAccount;
    
    //Sign-up constructor
    public Home(BankAccount account, string code)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        userCode = code;
        saldo = account.Saldo;
        currentAccount = account;
        NewPageSignIn();

    }

    //log-in constructor
    public Home(BankAccount account)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        NewPage();

    }

    private void NewPage()
    {
        //Visualizza il nome e cognome nella sezione del profilo
        user.Text = $"{name} {surname}";
        SaldoAccount.Text = $"{saldo}€";
    }

    private async void NewPageSignIn()
    {
        user.Text = $"{name} {surname}";
        SaldoAccount.Text = $"{saldo}€";
        await Task.Delay(500);
        PopUp userpopUp = new PopUp(userCode);
        this.ShowPopup(userpopUp);
    }

    private void Pagamenti_Clicked(object sender, EventArgs e)
    {

    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage("appoggio");
    }

    private void CloseAccount_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage(currentAccount);
    }

    private void reload_Clicked(object sender, EventArgs e)
    {
        SaldoAccount.Text = $"{currentAccount.Saldo}€";
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