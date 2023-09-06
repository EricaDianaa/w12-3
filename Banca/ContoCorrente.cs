using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{


    internal class ContoCorrente
    {

        public string NomeCorrentista { get; set; }
        public string Cognome { get; set; }
        public DateTime DataApertura { get; set; }
        public string NrConto { get; set; }
        public double Saldo { get; set; }
        public List<Movimenti> ListaMovimenti { get; set; } = new List<Movimenti>();


        public ContoCorrente(string nomeCorrentista, string cognome, DateTime dataApertura, string nrConto)
        {
            NomeCorrentista = nomeCorrentista;
            Cognome = cognome;
            DataApertura = dataApertura;
            NrConto = nrConto;
        }

        public class Movimenti
        {

            public string Operazione { get; set; }
            public double Importo { get; set; }
        }

    }
    public static class Banca
    {
        private static List<ContoCorrente> ListaContiCorrente = new List<ContoCorrente>();

        public static void MenuBanca()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("Lista Operazioni:");
            Console.WriteLine("1 - Crea nuovo conto corrente");
            Console.WriteLine("2 - Memorizzazione movimento");
            Console.WriteLine("3 - Mostra lista movimenti e saldo");
            Console.WriteLine("4- Mostra lista di tutti i conti");
            Console.WriteLine("5 - Esci");

            string scelta = Console.ReadLine();
            if (scelta == "1")
            {
                NewConto();
                MenuBanca();
            }
            else if (scelta == "2")
            {
                MemorizzaMovimentiConto();
                MenuBanca();
            }
            else if (scelta == "3")
            {
                MostraListaMovimenti();
                MenuBanca();
            }
            else if (scelta == "4")
            {
                MostraTuttiConti();
                MenuBanca();
            }
            else if (scelta == "5")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Scelta non valida");
                MenuBanca();
            }
        }
        private static void NewConto()
        {
            Console.WriteLine("Inserire Nome correntista:");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserire Cognome correntista:");
            string cognome = Console.ReadLine();

            DateTime dataApertura = DateTime.Now;

            Console.WriteLine("Inserire numero conto:");
            string numeroConto = Console.ReadLine();

            ContoCorrente nuovoCorrentista = new ContoCorrente(nome, cognome, dataApertura, numeroConto);

            ListaContiCorrente.Add(nuovoCorrentista);

        }

        private static void MemorizzaMovimentiConto()
        {
            Console.WriteLine("Inserire numero di conto:");
            string verificaConto = Console.ReadLine();

            var contoUtente = ListaContiCorrente.Find((lista) => lista.NrConto == verificaConto);

            if (contoUtente != null)
            {
                Console.WriteLine("Inserire operazione: 1 per accredito o  2 addebito'");
                string operazione = Console.ReadLine();

                if (operazione == "1" || operazione == "2")
                {
                    Console.WriteLine("Inserire importo:");
                    try
                    {
                        double importo = Convert.ToDouble(Console.ReadLine());

                        if (operazione == "1")
                        {
                            operazione = "accredito";
                            contoUtente.Saldo += importo;
                        }
                        else
                        {
                            operazione = "addebito";
                            contoUtente.Saldo -= importo;
                        }

                        ContoCorrente.Movimenti movimento = new ContoCorrente.Movimenti();
                        movimento.Operazione = operazione;
                        movimento.Importo = importo;

                        contoUtente.ListaMovimenti.Add(movimento);
                    }
                    catch { Console.WriteLine("Inserire numero di conto:"); }
                }
                else
                {
                    Console.WriteLine("Operazione non valida");
                }
            }
            else
            {
                Console.WriteLine("erore inserire un numero");
                MemorizzaMovimentiConto();
            }
        }

        private static void MostraListaMovimenti()
        {
            Console.WriteLine("Inserire numero di conto:");
            string verificaConto = Console.ReadLine();
            int i = 0;
            var contoUtente = ListaContiCorrente.Find((lista) => lista.NrConto == verificaConto);
            contoUtente.ListaMovimenti.ForEach(movimenti =>
            {
                Console.WriteLine($"movimento numero {i}");
                Console.WriteLine($"operazione di {movimenti.Operazione} di {movimenti.Importo} €");
                i++;
            });
            Console.WriteLine(contoUtente.Saldo);

        }
        private static void MostraTuttiConti()
        {
            foreach (var item in ListaContiCorrente)
            {
                Console.WriteLine($"conto di {item.NomeCorrentista} {item.Cognome} aperto in data{item.DataApertura.ToString("yyyy/MM/dd")}");
                Console.WriteLine($"{item.NrConto}");
                Console.WriteLine($"{item.Saldo} €");


            }
        }

    }
}
