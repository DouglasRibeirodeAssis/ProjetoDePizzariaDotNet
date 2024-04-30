using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=pizzaria;user=root;password=positivo");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Cliente>()
        .HasMany(c => c.Enderecos)
        .WithOne() 
        .HasForeignKey(e => e.ClienteId)
        .OnDelete(DeleteBehavior.Cascade); 
}


    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
}
