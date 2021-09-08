using GestionBanque09.Model;
using System;
using System.Collections.Generic;

namespace GestionBanque09
{
    class Program
    {
        static void Main(string[] args)
        {
            // Personnes
            Console.WriteLine("\n*** Création des personnes ***");
            Personne p = new Personne("John", "Doe", new DateTime(2000, 1, 1));
            Personne p2 = new Personne("Geerts", "Quentin", new DateTime(1996, 04, 03));

            // Courants & Epargne
            Console.WriteLine("\n*** Création des comptes (courants/épargnes) ***");
            Courant c = new Courant("0000001", p);
            Courant c2 = new Courant("0000002", p);
            Courant c3 = new Courant("0000003", p2);
            Epargne e1 = new Epargne("0000004", p2);

            // Banques
            Console.WriteLine("\n*** Création de la banque ***");
            Banque b = new Banque();
            b.Nom = "Ma Banque";

            Console.WriteLine("\n*** Opération de la banque ***");
            b.Ajouter(c);
            b.Ajouter(c2);
            b.Ajouter(c3);


            c.Depot(100);
            c.LigneDeCredit = 100;
            Console.WriteLine("solde compte");
            Console.WriteLine(c.Solde);
            c.PassageEnNegatifEvent += c.SoldeNegatif;
            c.PassageEnNegatifEvent += b.Message;
            c.Retrait(150);


        

            try
            {
                c.LigneDeCredit = -1;
                Console.WriteLine("OK");
            }
            catch (InvalidOperationException invalidOperation)
            {
                Console.WriteLine(invalidOperation.Message);
            }

           

            Console.WriteLine("\n*** Dépots et retraits ***");
            try
            {
                e1.Depot(-1);
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine($"{outOfRange.ParamName}");
            }
            try
            {
                e1.Depot(50);

               
                e1.Retrait(100);


                e1.Retrait(50);


                b["0000001"].Depot(500);
                b["0000002"].Depot(500);
                b["0000001"].Retrait(300);

                b["0000003"].Depot(500);
                b["0000003"].Retrait(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            // Utilisation des interfaces
            Console.WriteLine("\n*** Utilisation des interfaces - [0000001] ***");
            Console.WriteLine("IBanker");
            IBanker banker = b["0000001"];
            try
            {
                banker.Depot(50);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Solde [0000001]" + banker.Solde);
            
            try
            {
                banker.Retrait(50);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Solde [0000001]" + banker.Solde);
            Console.WriteLine("Application des intérêts");
            banker.AppliquerInteret();

            Console.WriteLine();
            Console.WriteLine("ICustomer");
            ICustomer customer = b["0000001"];
            try
            {
                customer.Depot(50);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Solde [0000001]" + customer.Solde);
            try
            {
                customer.Retrait(60);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Solde [0000001]" + customer.Solde);

            Console.WriteLine();

            Console.WriteLine("Avant les interêts : ");
            Console.WriteLine("Solde [0000001]" + b["0000001"].Solde);
            Console.WriteLine("Solde [0000002]" + b["0000002"].Solde);
            Console.WriteLine("Solde [0000003]" + b["0000003"].Solde);

            foreach (KeyValuePair<string, Compte> kvp in b.Compte)
            {
                kvp.Value.AppliquerInteret();
            }

            Console.WriteLine();

            Console.WriteLine("Après les interêts : ");
            Console.WriteLine("Solde [0000001]" + b["0000001"].Solde);
            Console.WriteLine("Solde [0000002]" + b["0000002"].Solde);
            Console.WriteLine("Solde [0000003]" + b["0000003"].Solde);

            Console.WriteLine();
            Console.WriteLine("Avoirs");
            Console.WriteLine("p  : " + b.AvoirDesComptes(p));
            Console.WriteLine("p2 : " + b.AvoirDesComptes(p2));
        }
    }
}
