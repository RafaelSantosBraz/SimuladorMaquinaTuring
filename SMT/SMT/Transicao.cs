using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Transicao
    {
        private int estadoAtual;
        private char leituraFita;
        private char escritaFita;
        private int proximoEstado;
        private char direcao;

        public Transicao(int estadoAtual, char leituraFita, char escritaFita, int proximoEstado, char direcao)
        {
            this.EstadoAtual = estadoAtual;
            this.LeituraFita = leituraFita;
            this.EscritaFita = escritaFita;
            this.ProximoEstado = proximoEstado;
            this.Direcao = direcao;
        }

        public int EstadoAtual { get => estadoAtual; set => estadoAtual = value; }
        public char LeituraFita { get => leituraFita; set => leituraFita = value; }
        public char EscritaFita { get => escritaFita; set => escritaFita = value; }
        public int ProximoEstado { get => proximoEstado; set => proximoEstado = value; }
        public char Direcao { get => direcao; set => direcao = value; }
    }
}
