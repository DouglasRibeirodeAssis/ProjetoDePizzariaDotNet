using Microsoft.EntityFrameworkCore;

public static class PedidoApi
{
    public static void MapPedidoApi(this WebApplication app)
    {
        var group = app.MapGroup("/pedidos");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var pedido = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null) return Results.NotFound();

            return Results.Ok(pedido);
        });

        group.MapPost("/", async (Pedido pedido, BancoDeDados db) =>
        {
            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();
            return Results.Created($"/pedidos/{pedido.Id}", pedido);
        });

        group.MapPut("/{id}", async (int id, Pedido updatedPedido, BancoDeDados db) =>
        {
            var pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null) return Results.NotFound();

            pedido.data = updatedPedido.data ?? pedido.data;
            pedido.Total = updatedPedido.Total ?? pedido.Total;
            pedido.Cliente = updatedPedido.Cliente ?? pedido.Cliente;
            pedido.Itens = updatedPedido.Itens ?? pedido.Itens;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null) return Results.NotFound();

            db.Pedidos.Remove(pedido);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
