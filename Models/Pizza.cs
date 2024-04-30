

public class Pizza {

    public int Id { get; set; }
    public string? Nome { get; set; }
    public double? Valor { get; set; }
    public string Ingredientes { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Ingredientes: {Ingredientes} Valor: {Valor}";
    }
}