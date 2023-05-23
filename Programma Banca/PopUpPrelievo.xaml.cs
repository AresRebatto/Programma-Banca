using CommunityToolkit.Maui.Views;

namespace Programma_Banca;

public partial class PopUpPrelievo : Popup
{
	double saldo;
	Bank banca;
	public PopUpPrelievo(double saldo, Bank banca)
	{
		InitializeComponent();
		this.saldo = saldo;
		this.banca = banca;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(Convert.ToDouble(ImportoPrev.Text) > saldo)
		{
            BorderImport.Stroke = Color.FromArgb("#FF0000");
        }else
		{
            banca.TransazioniOut.Add(Convert.ToDouble(ImportoPrev.Text));
            Close();
        }
    }

    private void ClosePrev_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}