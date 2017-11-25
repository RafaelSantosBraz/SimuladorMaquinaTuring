using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //biblioteca entrada/saída

namespace SMT
{
    class MT
    {
        private int q0;
        private int[] f;
        private char branco;
        private char inicio;
        private List<Transicao> transicoes;
        private int estadoAtual;

        public MT()
        {

        }

        public int Q0 { get => q0; set => q0 = value; }
        public int[] F { get => f; set => f = value; }
        public char Branco { get => branco; set => branco = value; }
        public char Inicio { get => inicio; set => inicio = value; }
        public int EstadoAtual { get => estadoAtual; set => estadoAtual = value; }
        internal List<Transicao> Transicoes { get => transicoes; set => transicoes = value; }

        public bool carregarEspecificacoes(string caminhoArquivo) //le um arquivo de texto com as especificações da MT e configura automaticamente
        {
            StreamReader arquivo;
            try
            {
                arquivo = File.OpenText(caminhoArquivo);
                string linha = arquivo.ReadLine();
                string[] campos = linha.Split(';');
                this.Q0 = Int32.Parse(campos[0]);
                this.EstadoAtual = this.Q0;
                string[] estadosFinais = campos[1].Split(',');
                this.F = new int[estadosFinais.Length];
                int cont = 0;
                foreach (string estado in estadosFinais)
                {
                    this.F[cont] = Int32.Parse(estadosFinais[cont]);
                    cont++;
                }
                this.Branco = campos[2][0];
                this.Inicio = campos[3][0];
                transicoes = new List<Transicao>();
                while (!arquivo.EndOfStream)
                {
                    linha = arquivo.ReadLine();
                    campos = linha.Split(',');
                    Transicao transicao = new Transicao(Int32.Parse(campos[0]), campos[1][0], campos[2][0], Int32.Parse(campos[3]), campos[4][0]);
                    transicoes.Add(transicao);
                }
                arquivo.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Transicao funcaoTransicao(int estadoAtual, char leiturafita) //recebe o estado atual e o símbolo da fita para retornar a transicao completa correspondente
        {
            foreach (Transicao transicao in this.Transicoes)
            {
                if (transicao.EstadoAtual == estadoAtual && transicao.LeituraFita == leiturafita)
                {
                    return transicao;
                }        
            }
            return null;
        }

        public Resposta executar(Fita fita) //executa a MT configurada com uma fita específica e retorna uma resposta para o processamento
        {
            Transicao transicao = funcaoTransicao(this.EstadoAtual, fita.Atual.Simbolo);
            while (transicao != null)
            {
                fita.Atual.Simbolo = transicao.EscritaFita;
                switch (transicao.Direcao)
                {
                    case 'D':
                        if (!fita.direita())
                        {
                            fita.novaPosicao(this.Branco, fita.Atual, null);
                        }
                        break;
                    case 'E':
                        if (!fita.esquerda())
                        {
                            fita.novaPosicao(this.Branco, null, fita.Atual);
                        }
                        break;
                    case 'S':
                        break;
                    default:
                        return null;
                }
                this.EstadoAtual = transicao.ProximoEstado;
                transicao = funcaoTransicao(this.EstadoAtual, fita.Atual.Simbolo);
            }            
            if (this.F.Contains(this.EstadoAtual))
            {
                this.EstadoAtual = this.Q0;
                return new Resposta(fita, 1);
            }
            else
            {
                this.EstadoAtual = this.Q0;
                return new Resposta(fita, 0);
            }
        }
    }
}
