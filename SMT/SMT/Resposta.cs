using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Resposta
    {
        private Fita fita;
        private int resultado;

        public Resposta(Fita fita, int resultado)
        {
            this.Fita = fita;
            this.Resultado = resultado;
        }

        public int Resultado { get => resultado; set => resultado = value; }
        internal Fita Fita { get => fita; set => fita = value; }
    }
}
