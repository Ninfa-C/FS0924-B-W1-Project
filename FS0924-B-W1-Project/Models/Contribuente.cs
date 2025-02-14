using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FS0924_B_W1_Project.Models
{
    public partial class Contribuente
    {
        public string? Nome { get; private set; }
        public string? Cognome { get; private set; }
        public DateTime DataDiNascita { get; private set; }
        public string CodiceFiscale { get; private set; }
        public string Sesso { get; private set; }
        public string ComuneDiResidenza { get; private set; }
        public decimal RedditoAnnuale { get; private set; }
        public decimal ImpostaDaPagare { get; private set; }
        public Contribuente(string nome, string cognome, DateTime data, string cf, string sesso, string comune, decimal reddito)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = data;
            CodiceFiscale = cf;
            Sesso = sesso;
            ComuneDiResidenza = comune;
            RedditoAnnuale = reddito;
            ImpostaDaPagare = Imposta(reddito);
        }

        public static decimal Imposta(decimal reddito)
        {
            return reddito switch
            {
                <= 15000 => reddito * 0.23m,
                <= 28000 => 3450m + (reddito - 15000) * 0.27m,
                <= 55000 => 6960m + (reddito - 28000) * 0.38m,
                <= 75000 => 17220m + (reddito - 55000) * 0.41m,
                _ => 25420m + (reddito - 75000) * 0.43m,
            };
        }

        public static Contribuente Registrazione()
        {
        nome:
            Console.Write("Inserisci il nome: ");
            var name = MyRegex1().Replace(Console.ReadLine()!, " ").Trim();
            if (string.IsNullOrEmpty(name) || !MyRegex().IsMatch(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Nome non valido");
                goto nome;
            }
        cognome:
            Console.Write("Inserisci il cognome: ");
            var surname = MyRegex1().Replace(Console.ReadLine()!, " ").Trim();
            if (string.IsNullOrEmpty(surname) || !MyRegex().IsMatch(surname) || string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Cognome non valido");
                goto cognome;
            }
        date:
            Console.Write("Inserisci la data di nascita (gg/mm/aaaa): ");
            var date = Console.ReadLine()!;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                if (result >= DateTime.Today)
                {
                    Console.WriteLine("La data di nascita non può superare il giorno corrente.");
                    goto date;
                }
            }
            else
            {
                Console.WriteLine("Formato non valido. Usa il formato gg/mm/aaa");
                goto date;
            }
        sesso:
            Console.Write("Inserisci il sesso (M/F/NB/Altro): ");
            var genere = Console.ReadLine()!.ToUpper();
           if (genere != "M" && genere != "F" && genere != "NB" && genere != "ALTRO")
            {
                Console.WriteLine("Sesso non valido");
                goto sesso;
            }
           
        luogo:
            Console.Write("Inserisci il comune di redisenza: ");
            var luogo = Console.ReadLine()!;
            if (string.IsNullOrEmpty(luogo) || !MyRegex().IsMatch(luogo) || string.IsNullOrWhiteSpace(luogo))
            {
                Console.WriteLine("Comune di residenza non valido");
                goto luogo;
            }
        cf:
            Console.Write("Inserisci il codice fiscale: ");
            var cf = Console.ReadLine()!.ToUpper();
            if (string.IsNullOrEmpty(cf) || !CFRegex().IsMatch(cf) || string.IsNullOrWhiteSpace(cf))
            {
                Console.WriteLine("Codice fiscale non valido. Deve avere 16 caratteri e rispettare il formato corretto.");
                goto cf;
            }

        reddito:

            Console.Write("Inserisci il reddito annuale: ");
            var reddito = Console.ReadLine()!;
            if (!decimal.TryParse(reddito, out decimal total) || total < 0)
            {
                Console.WriteLine("Reddito non valido.");
                goto reddito;
            }

            return new Contribuente(name, surname, result, cf, genere, luogo, total);
        }

        public void StampaDettagliContribuente()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"nato il {DataDiNascita:dd/MM/yyyy},");
            Console.WriteLine($"residente in {ComuneDiResidenza},");
            Console.WriteLine($"codice fiscale: {CodiceFiscale},");
            Console.WriteLine($"Reddito dichiarato: €{RedditoAnnuale:N2}");
            Console.WriteLine($"IMPOSTA DA VERSARE: €{ImpostaDaPagare:N2}");
            Console.WriteLine("==================================================");
        }


        [GeneratedRegex(@"^[a-zA-ZàèéìòùÀÈÉÌÒÙçÇñÑäëïöüÄËÏÖÜ' -]+$")]
        private static partial Regex MyRegex();

        [GeneratedRegex(@"^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$")]
        private static partial Regex CFRegex();
        [GeneratedRegex(@"\s+")]
        private static partial Regex MyRegex1();
    }

}
