using System;
using AluguelDeCarro.Entidades;
using AluguelDeCarro.Serviços;
using System.Globalization;

namespace AluguelDeCarro
{
    class Program
    {
        static void Main(string[] args)
        {
            bool j = true;
            while (j == true)
            {

                j = false;
                Console.WriteLine("Entre com os dados");
                Console.Write($"Modelo do veiculo: ");
                Veiculo veiculo = new Veiculo(Console.ReadLine());
                Console.Write($"Data da retirada: [dd/MM/aaaa HH:mm] ");

                bool i = true;
                DateTime inicio = DateTime.Now;
                DateTime fim = DateTime.Now;

                while (i == true)
                {
                    i = false;
                    try
                    {
                        inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        Console.Write($"Data da entrega: [dd/MM/aaaa HH:mm] ");
                        fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        if (fim < inicio)
                        {
                            throw new ApplicationException("data de entrega e antes da retirada, favor informar dados reais!");
                            throw new SystemException();
                        }
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{erro.Message}\nEntre com data e hora no formato dd/MM/yyyy HH:mm");
                        i = true;
                    }
                    
                }
                try
                {
                    Console.Write($"Informe o preço por Hora: ");
                    double precoHora = double.Parse(Console.ReadLine());
                    Console.Write($"Informe o preço por Dia: ");
                    double precoDia = double.Parse(Console.ReadLine());

                    AlugelCarro aluguel = new AlugelCarro(inicio, fim, veiculo);

                    ServicoAluguel servico = new ServicoAluguel(precoHora, precoDia, new TaxaBrasileira());

                    servico.ProcessoPagamento(aluguel);

                    Console.WriteLine("Pagamento");
                    Console.WriteLine(aluguel.NotaPagamento);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Erro ! Dados incorreto Tente novamento.");
                    j = true;
                }
            }
        }
    }
}
