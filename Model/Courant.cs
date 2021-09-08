using System;

namespace GestionBanque09.Model
{
    public class Courant : Compte
    {
        
        // Attributs
        private double _LigneDeCredit;

        // Propriétés
        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("La ligne de crédit doit être strictement positive.");

                _LigneDeCredit = value;
            }
        }

        // Constructeurs
        public Courant(string Numero, Personne Titulaire) : base(Numero, Titulaire)
        {

        }

        public Courant(string Numero, Personne Titulaire, double Solde) : base(Numero, Titulaire, Solde)
        {

        }

        // Méthodes
        public override void Retrait(double Montant)
        {
            Retrait(Montant, LigneDeCredit);
           
        }

        public void SoldeNegatif(object c)
        {
            Console.WriteLine("Attention vous venez de passé en négatif");
        }

        protected override double CalculInteret()
        {
            return (Solde < 0) ? Solde * .0975 : Solde * .03;
        }
    }
}
