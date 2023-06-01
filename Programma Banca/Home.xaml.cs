using CommunityToolkit.Maui.Views;
//using Microsoft.UI.Xaml.Controls.Primitives;
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
    Bank banca;
    
    //Sign-up constructor
    public Home(BankAccount account, string code, Bank banca)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        userCode = code;
        saldo = account.Saldo;
        currentAccount = account;
        this.banca = banca;
        NewPageSignIn();

    }

    //log-in constructor
    public Home(BankAccount account, Bank banca)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        this.banca = banca;
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
        App.Current.MainPage = new MainPage(banca);
    }

    private void CloseAccount_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage(currentAccount);
    }

    private void reload_Clicked(object sender, EventArgs e)
    {
        SaldoAccount.Text = $"{currentAccount.Saldo}€";
    }

    private async void Deposita_Clicked(object sender, EventArgs e)
    {
        await Task.Delay(500);
        this.ShowPopup(new PopUpDeposito(currentAccount, banca));
        do
        {
            await Task.Delay(500);
            SaldoAccount.Text = $"{currentAccount.Saldo}€";
        } while (currentAccount.Transazione == false);

        currentAccount.Transazione = false;
    }

    private async void Preleva_Clicked(object sender, EventArgs e)
    {
        await Task.Delay(500);
        this.ShowPopup(new PopUpPrelievo(currentAccount, banca));
        do
        {
            await Task.Delay(500);
            SaldoAccount.Text = $"{currentAccount.Saldo}€";
        } while (currentAccount.Transazione == false);

        currentAccount.Transazione = false;
    }

    private void InviaSoldi_Clicked(object sender, EventArgs e)
    {

    }
}