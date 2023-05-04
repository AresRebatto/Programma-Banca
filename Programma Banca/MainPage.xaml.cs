using Microsoft.Maui.Platform;

namespace Programma_Banca;

public partial class MainPage : ContentPage
{
	Bank bancaAffidabile = new Bank();
    bool singUp = false;

	public MainPage()
	{
		InitializeComponent();
	}

    private void submit_Clicked(object sender, EventArgs e)
    {
        if(singUp)
        {
            Random rnd = new Random();
            string code = $"{rnd.Next(1, 11)}-{rnd.Next(11, 21)}-{rnd.Next(21,31)}-{rnd.Next(31, 41)}-{rnd.Next(1, 1025)}";
            bancaAffidabile.OpenAccount(Nomesnup.Text, Cognomesnup.Text, Emailsnup.Text, code);
        }
    }

    private void LogIn_Clicked(object sender, EventArgs e)
    {
        singUp = false;

        BorderName.IsVisible = true;
        BorderSurname.IsVisible = true;
        BorderEmail.IsVisible = true;
        BorderCode.IsVisible = true;

        BorderNamesnup.IsVisible = false;
        BorderSurnamesnup.IsVisible = false;
        BorderEmailsnup.IsVisible = false;
        BorderCodFiscale.IsVisible = false;
        BorderNum.IsVisible = false;

        LogIn.BackgroundColor = Color.FromArgb("#FE982C");
        LogIn.TextColor = Color.FromArgb("#000000");
        SingUp.BackgroundColor = Color.FromArgb("#242627");
        SingUp.TextColor = Color.FromArgb("#FFFFFF");
        submit.Text = "Log-in";
    }

    private void SingUp_Clicked(object sender, EventArgs e)
    {
        singUp = true;

        BorderName.IsVisible = false;
        BorderSurname.IsVisible = false;
        BorderEmail.IsVisible = false;
        BorderCode.IsVisible = false;

        BorderNamesnup.IsVisible = true;
        BorderSurnamesnup.IsVisible = true;
        BorderEmailsnup.IsVisible = true;
        BorderCodFiscale.IsVisible = true;
        BorderNum.IsVisible = true;

        LogIn.BackgroundColor = Color.FromArgb("#242627");
        LogIn.TextColor = Color.FromArgb("#FFFFFF");
        SingUp.BackgroundColor = Color.FromArgb("#FE982C");
        SingUp.TextColor = Color.FromArgb("#000000");
        submit.Text = "Sign-up";
    }
}

