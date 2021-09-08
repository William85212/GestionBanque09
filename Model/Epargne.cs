using System;

namespace GestionBanque09.Model
{
    public class Epargne : Compte
    {
        // Attributs
        private DateTime _DateDernierRetrait;

        // Propriétés
        public DateTime DernierRetrait
        {
            get { return _DateDernierRetrait; }
            private set { _DateDernierRetrait = value; }
        }

        // Constructeurs
        public Epargne(string Numero, Personne Titulaire) : base(Numero, Titulaire)
        {

        }

        public Epargne(string Numero, Personne Titulaire, double Solde) : base(Numero, Titulaire, Solde)
        {

        }
        // Méthodes
        public override void Retrait(double Montant)
        {
            double AncienSolde = Solde;
            base.Retrait(Montant);

            if (Solde != AncienSolde)
                DernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            return Solde * .045;
        }
    }
}
