using CommunityToolkit.Maui.Views;

namespace Programma_Banca;

public partial class PopUpPrelievo : Popup
{
	double saldo;
	Bank banca;
	BankAccount account;
	public PopUpPrelievo(BankAccount account, Bank banca)
	{
		InitializeComponent();
		this.saldo = account.Saldo;
		this.banca = banca;
		this.account = account;

	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(Convert.ToDouble(ImportoPrev.Text) > saldo)
		{
            BorderImport.Stroke = Color.FromArgb("#FF0000");
        }else
		{
            banca.TransazioniOut.Add(Convert.ToDouble(ImportoPrev.Text));
            if (banca.TransazioniOut.Last() < saldo)//Verifica se il valore inserito nel PopUp è stato inserito valore minore del saldo
            {
                account.Withdraw(banca.TransazioniOut.Last());
                account.Transazione = true;
                Close();
            }
            else
            {
                BorderImport.Stroke = Color.FromArgb("#FF0000");
            }
            

        }
    }

    private void ClosePrev_Clicked(object sender, EventArgs e)
    {
            Close();
    }
}