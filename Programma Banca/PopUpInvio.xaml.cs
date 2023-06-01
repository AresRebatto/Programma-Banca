using CommunityToolkit.Maui.Views;
namespace Programma_Banca;

public partial class PopUpInvio : Popup
{
    double saldo;
    Bank banca;
    BankAccount account;
    string nome;
    public PopUpInvio(BankAccount account, Bank banca)
    {
        InitializeComponent();
        this.saldo = account.Saldo;
        this.banca = banca;
        this.account = account;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        bool verificaNome = false;
        bool verificaImporto = false;
        nome = NomeInvio.Text;
        banca.TransazioniOut.Add(Convert.ToDouble(ImportoInvio.Text));
        if(banca.TransazioniOut.Last() < account.Saldo)
        {
            BorderImport.Stroke = Color.FromArgb("#FFFFFF");
            verificaImporto = true;
        }else
        {
            BorderImport.Stroke = Color.FromArgb("#FF0000");
            verificaImporto = false;
        }

        if(VerificaUtente(nome))
        {
            verificaNome = true;
            BorderName.Stroke = Color.FromArgb("#FFFFFF");
        }
        else
        {
            verificaNome = false;
            BorderName.Stroke = Color.FromArgb("#FF0000");
        }
        //verificaNome = VerificaUtente(nome) ? true : false;

        if(verificaNome && verificaImporto)
        {
            account.Send(banca.TransazioniOut.Last(), banca, nome);
            account.Transazione = true;
            Close();
        }
        
    }

    private void ClosePrev_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    bool VerificaUtente(string name)
    { 
        foreach(BankAccount utenti in banca.Account)
        {
            if(name == utenti.Nome )
            {
                return true;
            }
        }

        return false;
    }
}