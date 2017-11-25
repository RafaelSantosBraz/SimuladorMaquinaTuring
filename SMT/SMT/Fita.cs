using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Fita
    {
        Posicao inicio;   

        public Fita(char simbolo)
        {
            this.inicio = new Posicao(simbolo);
        }
    }
}
