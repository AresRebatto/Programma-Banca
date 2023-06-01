using CommunityToolkit.Maui.Views;

namespace Programma_Banca;

public partial class PopUpDeposito : Popup
{
    double saldo;
    Bank banca;
    BankAccount account;
    public PopUpDeposito(BankAccount account, Bank banca)
    {
        InitializeComponent();
        this.saldo = account.Saldo;
        this.banca = banca;
        this.account = account;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
       
        banca.TransazioniIn.Add(Convert.ToDouble(ImportoDep.Text));
        account.Deposit(banca.TransazioniIn.Last());
        account.Transazione = true;
        Close();
    }

    private void ClosePrev_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}