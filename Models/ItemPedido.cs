

public class ItemPedido {

    public int Id { get; set; }
    
    public Pedido? Pedido { get; set; }

    public Pizza? Pizza { get; set; }

    public double? Valor { get; set; }
    public int? Quantidade { get; set; }
    public double? Total { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Pedido: {Pedido}, Pizza: {Pizza}, Valor: {Valor}, Quantidade: {Quantidade}, Total: {Total}";
    }
}