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
    public Home(string nome, string cognome, string code, double saldo)
    {
        InitializeComponent();
        name = nome;
        surname = cognome;
        userCode = code;
        this.saldo = saldo;
        NewPage();

    }

    private void NewPage()
    {
        //Visualizza il nome e cognome nella sezione del profilo
        user.Text = $"{name} {surname}";
    }

    private void Pagamenti_Clicked(object sender, EventArgs e)
    {

    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {

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