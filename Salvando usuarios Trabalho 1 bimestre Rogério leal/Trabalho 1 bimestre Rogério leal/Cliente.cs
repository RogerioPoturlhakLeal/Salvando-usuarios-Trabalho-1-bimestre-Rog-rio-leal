using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_1_bimestre_Rogério_leal
{
    class Cliente
    {

        public string Nome { get; set; }
        public string Fone { get; set; }
        public string EMail { get; set; }
        public string Data { get; set; }


        public override string ToString()
        {
            return " Nome: " + Nome + ", Fone: " + Fone + " EMail: " + EMail + " Data: " + Data ;
        }
    }
}
