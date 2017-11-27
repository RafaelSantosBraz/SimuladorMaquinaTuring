using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Fita
    {
        private Posicao inicio;
        private Posicao atual;

        internal Posicao Inicio { get => inicio; set => inicio = value; }
        internal Posicao Atual { get => atual; set => atual = value; }

        public Fita(string simbolos)
        {
            carregar(simbolos);
        }

        public void novaPosicao(char simbolo, Posicao ant, Posicao prox) //cria uma nova posição em um ponto específico da fita
        {
            Posicao aux = new Posicao(simbolo);
            aux.Ant = ant;
            aux.Prox = prox;
            if (ant == null && prox == null)
            {
                this.Atual = this.Inicio = aux;
                return;
            }
            if (ant != null)
            {
                ant.Prox = aux;
            }
            if (prox != null)
            {
                prox.Ant = aux;
            }
            this.Atual = aux;
        }

        public void carregar(string simbolos) //faz a leitura de uma string e cria posições para cada símbolo
        {
            this.Inicio = this.Atual = null;
            foreach (char s in simbolos)
            {
                novaPosicao(s, this.Atual, null);
            }
            this.Atual = this.Inicio;
        }

        public bool direita() //move o ponteiro atual para o elemento à direita
        {
            if (this.Atual.Prox != null)
            {
                this.Atual = this.Atual.Prox;
                return true;
            }
            return false;
        }

        public bool esquerda() //move o ponteiro atual para o elemento à esquerda
        {
            if (this.Atual.Ant != null)
            {
                this.Atual = this.Atual.Ant;
                return true;
            }
            return false;
        }

        public string imprimir() //retorna uma string com todos os elementos instanciados na fita a partir da esquerda
        {
            string fita = "";
            Posicao aux = this.Atual;
            Posicao anterior = null;
            while (aux != null)
            {
                anterior = aux;
                aux = aux.Ant;
            }
            while (anterior != null)
            {
                fita += anterior.Simbolo;
                anterior = anterior.Prox;
            }
            return fita;
        }
    }
}
