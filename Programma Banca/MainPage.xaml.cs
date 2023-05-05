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
        bool nameError = true;
        bool surnameError = true;
        bool emailError = true;
        bool codFisError = true;
        bool numTelError = true;
        string? numero = Num.Text;

        //Verifica dei valori della pagina di SignUp
        if (Num.Text == null && numero.Length != 9 && int.TryParse(numero, out int a)) 
        {
            BorderNum.Stroke = Color.FromArgb("#FF0000");
            numTelError = true;
        }else
        {
            BorderNum.Stroke = Color.FromArgb("#FFFFFF");
            numTelError = false;
        }

        if(Nomesnup.Text == null)
        {
            BorderNamesnup.Stroke = Color.FromArgb("#FF0000");
            nameError = true;
        }else
        {
            BorderNamesnup.Stroke = Color.FromArgb("#FFFFFF");
            nameError = false;
        }

        if (Cognomesnup.Text == null)
        {
            BorderSurnamesnup.Stroke = Color.FromArgb("#FF0000");
            surnameError = true;
        }else
        {
            BorderSurnamesnup.Stroke = Color.FromArgb("#FFFFFF");
            surnameError = false;
        }

        if(Emailsnup.Text==null)
        {
            BorderEmailsnup.Stroke = Color.FromArgb("#FF0000");
            emailError = true;
        }else
        {
            BorderEmailsnup.Stroke = Color.FromArgb("#FFFFFF");
            emailError = false;
        }

        if (Codfiscale.Text == null)
        {
            BorderCodFiscale.Stroke = Color.FromArgb("#FF0000");
            codFisError = true;
        }else
        {
            BorderCodFiscale.Stroke = Color.FromArgb("#FFFFFF");
            codFisError = false;
        }


        
        if (singUp && !nameError && !surnameError && !emailError && !codFisError && !numTelError)
        {
            Random rnd = new Random(); 
            //Genera il codice identificativo per l'utente
            string code = $"{rnd.Next(1, 11)}-{rnd.Next(11, 21)}-{rnd.Next(21,31)}-{rnd.Next(31, 41)}-{rnd.Next(1, 1025)}";
            bancaAffidabile.OpenAccount(Nomesnup.Text, Cognomesnup.Text, Emailsnup.Text, code);
            //Apre la page della Home
            App.Current.MainPage = new Home();
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

