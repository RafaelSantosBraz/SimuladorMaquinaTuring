using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Posicao
    {
        char simbolo;
        Posicao ant;
        Posicao prox;

        public Posicao(char simbolo)
        {
            this.simbolo = simbolo;
            this.ant = null;
            this.prox = null;
        }      
    }
}
