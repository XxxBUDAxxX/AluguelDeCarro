namespace AluguelDeCarro.Entidades
{
    class NotaPagamento
    {
        public double PagamentoBase { get; set; }
        public double Imposto { get; set; }

        public NotaPagamento(double pagamentoBase, double imposto)
        {
            PagamentoBase = pagamentoBase;
            Imposto = imposto;
        }

        public double TotalPagamento()
        {
            return PagamentoBase + Imposto;   
        }

        public override string ToString()
        {
            return $"Dados de pagamento \n" +
                $"Pagamento basico: R${PagamentoBase.ToString("f2")}\n" +
                $"Taxas: R${Imposto.ToString("f2")}\n" +
                $"Total do pagamento: R${TotalPagamento().ToString("f2")}";
        }

    }
}
