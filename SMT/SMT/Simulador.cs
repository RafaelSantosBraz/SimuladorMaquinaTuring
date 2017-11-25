using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Simulador
    {
        MT maquina;
        Fita[] fitas;

        public Simulador(MT maquina, Fita[] fitas)
        {
            this.maquina = maquina;
            this.fitas = fitas;
        }
    }
}
