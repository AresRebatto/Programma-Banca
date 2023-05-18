using CommunityToolkit.Maui.Views;

namespace Programma_Banca;

public partial class PopUp : Popup
{
	
	public PopUp(string code)
	{
		InitializeComponent();
		Codice.Text = code;
	}

	private void Chiudi_Clicked(object sender, EventArgs e)
	{
		Close();
	}
}