using System;

namespace GestionBanque09.Model
{
    interface ICustomer
    {
        // Propriété
        double Solde { get; }

        // Méthodes
        void Depot(double Montant);
        void Retrait(double Montant);

    }
}
