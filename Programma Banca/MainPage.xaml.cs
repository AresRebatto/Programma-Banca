using Microsoft.Maui.Platform;
using static Programma_Banca.Bank;

namespace Programma_Banca;

public partial class MainPage : ContentPage
{
    Bank bancaAffidabile;
    bool singUp = false;

	public MainPage()
	{
		InitializeComponent();
        bancaAffidabile = new Bank();

    }

    public MainPage(Bank banca)
    {
        InitializeComponent();
        bancaAffidabile = banca;
    }
    public MainPage(BankAccount accountDaChiudere)
    {
        InitializeComponent();
        bancaAffidabile.Close(accountDaChiudere);
    }
    bool VerificaEmail(string email)
    {
        if (email.Contains('@'))
        {
            string[] parts = email.Split('@');
            if (parts[1] == "gmail.com")
                return true;
            else
                return false;
        }
        else
            return false;


    }
    
    private void submit_Clicked(object sender, EventArgs e)
    {
        bool nameError = true;
        bool surnameError = true;
        bool emailError = true;
        bool codFisError = true;
        bool numTelError = true;
        string numero = Num.Text;
        

        //Verifica dei valori della pagina di SignUp
        if (singUp)
        {
        
            if (Num.Text == null || numero.Length != 10 || !int.TryParse(numero, out int a)) 
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

            if(Emailsnup.Text==null || !VerificaEmail(Emailsnup.Text))
            {
                BorderEmailsnup.Stroke = Color.FromArgb("#FF0000");
                emailError = true;
            }else
            {
                BorderEmailsnup.Stroke = Color.FromArgb("##FFFFFF");
                emailError = false;
            }

            if (Codfiscale.Text == null)
            {
                BorderCodFiscale.Stroke = Color.FromArgb("#FF0000");
                codFisError = true;
            }else
            {
                BorderCodFiscale.Stroke = Color.FromArgb("##FFFFFF");
                codFisError = false;
            }
            
            if(!nameError && !surnameError && !emailError && !codFisError && !numTelError)
            {
                Random rnd = new Random(); 
                //Genera il codice identificativo per l'utente
                string code = $"{rnd.Next(1, 11)}-{rnd.Next(11, 21)}-{rnd.Next(21,31)}-{rnd.Next(31, 41)}-{rnd.Next(1, 1025)}";
                double saldo = rnd.Next(1, 1001);
                bancaAffidabile.OpenAccount(Nomesnup.Text, Cognomesnup.Text, Emailsnup.Text, code, saldo);
                //Apre la page della Home
                App.Current.MainPage = new Home(bancaAffidabile.newAccount, code, bancaAffidabile) ;
            }
            
        }else
        {
            
            foreach (BankAccount account in bancaAffidabile.Account)
            {
                if (account.Nome == Nome.Text)
                {
                    BorderName.Stroke = Color.FromArgb("#FFFFFF");
                    nameError = true;
                    
                }
                else
                {
                    BorderName.Stroke = Color.FromArgb("#FF0000");
                    nameError = false;
                }

                if (account.Cognome == Cognome.Text)
                {
                    BorderSurname.Stroke = Color.FromArgb("#FFFFFF");
                    surnameError = true;
                }
                else
                {
                    BorderSurname.Stroke = Color.FromArgb("#FF0000");
                    surnameError = false;
                }

                if (account.Email == Email.Text)
                {
                    BorderEmail.Stroke = Color.FromArgb("#FFFFFF");
                    emailError = true;
                    
                }
                else
                {
                    BorderEmail.Stroke = Color.FromArgb("#FF0000");
                    emailError = false;
                }

                if (account.Code == Code.Text)
                {
                    if (nameError && surnameError && emailError)
                    {
                        App.Current.MainPage = new Home(account, bancaAffidabile);
                    }
                    BorderCode.Stroke = Color.FromArgb("#FFFFFF");

                }
                else
                {
                    BorderCode.Stroke = Color.FromArgb("#FF0000");
                }
            }
            
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

