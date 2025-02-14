using FS0924_B_W1_Project.Models;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=======FS0924-BACKEDN-W1-PROJECT=======");
Console.WriteLine("Scegli l'operazione da effettuare:");
Console.WriteLine("1.: Calcolare la tua imposta da pagare");
Console.WriteLine("2.: Visualizzare gli utenti registrati");
Console.WriteLine("3.: Esci");
Console.WriteLine("========================================");


options:
Console.Write("Scelta: ");
if (int.TryParse(Console.ReadLine(), out int scelta))
{
    switch (scelta)
    {
        case 1:
            Contribuente utente1 = Contribuente.Registrazione();
            utente1.StampaDettagliContribuente();
            ListaContribuenti.Add(utente1);
            goto options;

        case 2:
            ListaContribuenti.Print();
            goto options;
        case 3:
            Console.WriteLine("Uscita dal programma...");
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            goto options;
    }
}
else
{
    Console.WriteLine("Inserire un valore numerico valido.");
    goto options;
}
