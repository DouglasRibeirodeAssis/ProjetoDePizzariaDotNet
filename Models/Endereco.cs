public class Endereco {
    public int Id { get; set; }
    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? CEP { get; set; }
    
    public int? ClienteId { get; set; }

    public override string ToString() {
        return $"Id: {Id}, Rua: {Rua}, Numero: {Numero}, Bairro: {Bairro}, Cidade: {Cidade}, CEP: {CEP}, ClienteId: {ClienteId}";
    }
}
