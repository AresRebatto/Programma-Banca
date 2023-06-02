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
        Totale.Text = $"Al momento serviamo per un ammontare di: {currentAccount.Reload(banca)}€";
        NewPageSignIn();

    }

    //log-in constructor
    public Home(BankAccount account, Bank banca)
    {
        InitializeComponent();
        name = account.Nome;
        surname = account.Cognome;
        this.banca = banca;
        saldo = account.Saldo;
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
        //PopUp userpopUp = new PopUp(userCode);
        this.ShowPopup(new PopUp(userCode));
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
        App.Current.MainPage = new MainPage(banca, currentAccount);
    }

    private void reload_Clicked(object sender, EventArgs e)
    {
        Totale.Text = $"Al momento serviamo per un ammontare di: {currentAccount.Reload(banca)}€";
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

        movimento4.Text = movimento3.Text;
        movimento3.Text = movimento2.Text;
        movimento2.Text = movimento1.Text;
        movimento1.Text = $"+{banca.TransazioniIn.Last()}€";
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
        movimento4.Text = movimento3.Text;
        movimento3.Text = movimento2.Text;
        movimento2.Text = movimento1.Text;
        movimento1.Text = $"-{banca.TransazioniOut.Last()}€";
        currentAccount.Transazione = false;
    }

    private async void InviaSoldi_Clicked(object sender, EventArgs e)
    {
        await Task.Delay(500);
        this.ShowPopup(new PopUpInvio(currentAccount, banca));
        do
        {
            await Task.Delay(500);
            SaldoAccount.Text = $"{currentAccount.Saldo}€";
        } while (currentAccount.Transazione == false);
        movimento4.Text = movimento3.Text;
        movimento3.Text = movimento2.Text;
        movimento2.Text = movimento1.Text;
        movimento1.Text = $"-{banca.TransazioniOut.Last()}€";
        currentAccount.Transazione = false;
    }
}