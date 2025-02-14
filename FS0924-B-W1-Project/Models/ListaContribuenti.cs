using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS0924_B_W1_Project.Models
{
    public static class ListaContribuenti
    {
        private static List<Contribuente> listaContribuenti = new List<Contribuente>();

        public static void Add(Contribuente contribuente)
        {
            listaContribuenti.Add(contribuente);
        }

        public static void Print()
        {
            if (listaContribuenti.Count == 0)
            {
                Console.WriteLine("Nessun contribuente registrato.");
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("ELENCO CONTRIBUENTI REGISTRATI:");
            foreach (var contribuente in listaContribuenti)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
                Console.WriteLine($"Nato il: {contribuente.DataDiNascita:dd/MM/yyyy},");
                Console.WriteLine($"Residente in: {contribuente.ComuneDiResidenza},");
                Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale},");
                Console.WriteLine($"Reddito dichiarato: €{contribuente.RedditoAnnuale:N2}");
                Console.WriteLine($"IMPOSTA DA VERSARE: €{contribuente.ImpostaDaPagare:N2}");
            }
            Console.WriteLine("==================================================");
        }
    }
}
