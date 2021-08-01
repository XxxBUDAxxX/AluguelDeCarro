namespace AluguelDeCarro.Serviços
{
    class TaxaBrasileira : ITaxasSeviços
    {
        public double taxa (double valor)
        {
            if (valor <= 100.00)
            {
                return valor = valor * 20 / 100;
            }
            else
            {
                return valor = valor * 15 / 100;
            }
        }
        
    }
}
