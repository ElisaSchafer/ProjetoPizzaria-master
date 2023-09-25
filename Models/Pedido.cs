namespace ProjetoPizzaria.Models;

public class Pedido {
    public string Cliente { get; set; }
    public string Telefone { get; set; }
    public List<Pizzaria> Pizzas { get; set; } = new List<Pizzaria>();
}
