


public class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    
    public List<Endereco>? Enderecos { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, CPF: {CPF}, Telefone: {Telefone}, Email: {Email}";
    }

    public static implicit operator int(Cliente v)
    {
        throw new NotImplementedException();
    }
}