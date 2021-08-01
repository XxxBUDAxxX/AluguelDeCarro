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
            Console.WriteLine("Entre com os dados");
            Console.Write($"Modelo do veiculo: ");
            Veiculo veiculo = new Veiculo(Console.ReadLine());
            Console.Write($"Data da retirada: [dd/MM/aaaa] ");
            DateTime inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write($"Data da entrega: [dd/MM/aaaa] ");
            DateTime fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write($"Informe o preço por Hora: ");
            double precoHora = double.Parse(Console.ReadLine());
            Console.Write($"Informe o preço por Dia: ");
            double precoDia = double.Parse(Console.ReadLine());

            AlugelCarro aluguel = new AlugelCarro(inicio, fim, veiculo);

            ServicoAluguel servico = new ServicoAluguel(precoHora, precoDia);

            servico.ProcessoPagamento(aluguel);

            Console.WriteLine("Pagamento");
            Console.WriteLine(aluguel.NotaPagamento);
        }
    }
}
