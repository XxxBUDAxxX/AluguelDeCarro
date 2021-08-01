using System;
using System.Collections.Generic;
using AluguelDeCarro.Entidades;

namespace AluguelDeCarro.Serviços
{
    class ServicoAluguel
    {
        public double PrecoHora { get; private set; }
        public double PrecoDia { get; private set; }

        private TaxaBrasileira _taxaBrasileira = new TaxaBrasileira();

        public ServicoAluguel(double precoHora, double precoDia)
        {
            PrecoHora = precoHora;
            PrecoDia = precoDia;
        }

        public void ProcessoPagamento(AlugelCarro alugel) // crio uma variavel aluguel como os atributos de AluguelCarro
        {
            double total;
            TimeSpan diferença = alugel.Fim.Subtract(alugel.Inicio);
            if (diferença.TotalHours <= 12.0)
            {
                total = PrecoHora * Math.Ceiling(diferença.TotalHours);  // funçao Math.Ceiling arredonda para cima 
            }
            else
            {
                total = PrecoDia * Math.Ceiling(diferença.TotalDays);
            }

            double taxa = _taxaBrasileira.Imposto(total);   // usei a class TaxaBrasileira para calcular o imposto e jogar na variavel taxa
            alugel.NotaPagamento = new NotaPagamento(total, taxa); //declarei na minha class AluguelCarro NotaPagamento os valores de total e taxa

        }
    }
}
