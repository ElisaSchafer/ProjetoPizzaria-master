using ProjetoPizzaria.Models;
namespace ProjetoPizzaria.Models;

class Menu
{
    static List<Pizzaria> pizzas = new List<Pizzaria>();
    static List<Pedido> pedidos = new List<Pedido>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Bem-vindo ao Projeto de Pizzaria");
            Console.WriteLine("ESCOLHA UMA OPÇÃO:");
            Console.WriteLine("1 - Adicionar pizza");
            Console.WriteLine("2 - Listar pizzas");
            Console.WriteLine("3 - Criar Novo Pedido");
            Console.WriteLine("4 - Listar Pedidos");
            Console.WriteLine("5 - Pagar Pedido");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite sua opção: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        AdicionarPizzaria();
                        break;
                    case 2:
                        ListarPizzarias();
                        break;
                    case 3:
                        CriarNovoPedido();
                        break;
                    case 4:
                        ListarPedidos();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    static void AdicionarPizzaria()
    {
        Console.Write("Digite o nome da pizzaria: ");
        string nomePizzaria = Console.ReadLine();

        Console.Write("Digite os sabores da pizza separados por vírgula: ");
        string saboresPizza = Console.ReadLine();

        Console.Write("Digite o preço da pizza (formato 00.00): ");
        if (decimal.TryParse(Console.ReadLine(), out decimal precoPizza))
        {
            Pizzaria novaPizzaria = new Pizzaria
            {
                Nome = nomePizzaria,
                Sabores = saboresPizza,
                Preco = precoPizza
            };

            pizzas.Add(novaPizzaria);
            Console.WriteLine("PIZZARIA CRIADA COM SUCESSO!");
        }
        else
        {
            Console.WriteLine("Preço inválido. A pizzaria não foi criada. Tente novamente.");
        }
    }

    static void ListarPizzarias()
    {
        Console.WriteLine("Lista de Pizzarias:");
        if (pizzas.Count == 0)
        {
            Console.WriteLine("Nenhuma pizzaria encontrada.");
        }
        else
        {
            foreach (var pizzaria in pizzas)
            {
                MostrarDetalhesPizzaria(pizzaria);
            }
        }
    }

    static void CriarNovoPedido()
    {
        Pedido novoPedido = new Pedido();

        Console.Write("Quem é o Cliente? ");
        novoPedido.Cliente = Console.ReadLine();

        Console.Write("Quem é o Telefone do Cliente? ");
        novoPedido.Telefone = Console.ReadLine();

        do
        {
            Console.WriteLine("Escolha uma Pizza para adicionar:");
            ListarPizzarias();

            if (int.TryParse(Console.ReadLine(), out int pizzaEscolhida) && pizzaEscolhida >= 1 && pizzaEscolhida <= pizzas.Count)
            {
                novoPedido.Pizzas.Add(pizzas[pizzaEscolhida - 1]);
                Console.Write("Deseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO): ");
            }
            else
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
        } while (Console.ReadLine() == "1");

        pedidos.Add(novoPedido);
        Console.WriteLine("PEDIDO CRIADO");
        Console.WriteLine("TOTAL:");

        decimal totalPedido = CalcularTotalPedido(novoPedido);

        MostrarDetalhesPedido(novoPedido, totalPedido);
    }

    static void ListarPedidos()
    {
        Console.WriteLine("Lista de Pedidos:");
        if (pedidos.Count == 0)
        {
            Console.WriteLine("Nenhum pedido encontrado.");
        }
        else
        {
            foreach (var pedido in pedidos)
            {
                decimal totalPedido = CalcularTotalPedido(pedido);
                MostrarDetalhesPedido(pedido, totalPedido);
            }
        }
    }

    static decimal CalcularTotalPedido(Pedido pedido)
    {
        decimal totalPedido = 0;
        foreach (var pizza in pedido.Pizzas)
        {
            totalPedido += pizza.Preco;
        }
        return totalPedido;
    }

    static void MostrarDetalhesPizzaria(Pizzaria pizzaria)
    {
        Console.WriteLine($"NOME: {pizzaria.Nome}");
        Console.WriteLine($"SABORES: {pizzaria.Sabores}");
        Console.WriteLine($"PREÇO: {pizzaria.Preco.ToString("0.00")}");
    }

    static void MostrarDetalhesPedido(Pedido pedido, decimal totalPedido)
    {
        Console.WriteLine($"Cliente: {pedido.Cliente}");
        Console.WriteLine($"Telefone do Cliente: {pedido.Telefone}");
        Console.WriteLine("Pizzas do Pedido:");
        foreach (var pizza in pedido.Pizzas)
        {
            MostrarDetalhesPizzaria(pizza);
        }
        Console.WriteLine($"TOTAL: {totalPedido.ToString("0.00")}");
    }
}

