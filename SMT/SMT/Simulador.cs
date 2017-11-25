using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //biblioteca entrada/saída

namespace SMT
{
    class Simulador
    {
        private MT maquina;
        private List<Fita> fitas;

        public Simulador()
        {
            
        }

        internal MT Maquina { get => maquina; set => maquina = value; }
        internal List<Fita> Fitas { get => fitas; set => fitas = value; }

        public bool configurar(string caminhoArquivoMT, string caminhoArquivoFitas) //recebe dois arquivos de texto contendo as especificações da MT e as fitas para processar
        {
            MT mt = new MT();           
            if (!mt.carregarEspecificacoes(caminhoArquivoMT))
            {
                return false;
            }
            this.Maquina = mt;
            try
            {
                StreamReader arquivo;
                arquivo = File.OpenText(caminhoArquivoFitas);
                this.Fitas = new List<Fita>();
                while (!arquivo.EndOfStream)
                {
                    this.Fitas.Add(new Fita(arquivo.ReadLine()));
                }
                arquivo.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool executar(string caminhoArquivoResposta) //executa o simulador configurado e gera o arquivo output
        {
            StreamWriter arquivo;
            try
            {
                arquivo = File.CreateText(caminhoArquivoResposta);                
                foreach(Fita fita in this.Fitas)
                {
                    Resposta resposta = this.Maquina.executar(fita);
                    if (resposta != null)
                    {
                        arquivo.WriteLine(resposta.Resultado + ';' + resposta.Fita.imprimir());
                    }
                    else
                    {
                        arquivo.WriteLine("0;" + resposta.Fita.imprimir());
                    }
                }
                arquivo.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
