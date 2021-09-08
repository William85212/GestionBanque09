using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque09.Model
{
    class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : this("Solde insuffisant !")
        {
        }
        public SoldeInsuffisantException(string message) : base(message)
        {
        }
    }
}
