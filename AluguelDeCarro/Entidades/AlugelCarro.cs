using System;
using System.Collections.Generic;
using System.Text;

namespace AluguelDeCarro.Entidades
{
    class AlugelCarro
    {
        public DateTime Inicio { get; set; }
        public  DateTime Fim { get; set; }
        public Veiculo Veiculo { get; set; }
        public NotaPagamento NotaPagamento { get; set; }

        public AlugelCarro(DateTime inicio, DateTime fim, Veiculo veiculo)
        {
            Inicio = inicio;
            Fim = fim;
            Veiculo = veiculo;
            
        }
    }
}
