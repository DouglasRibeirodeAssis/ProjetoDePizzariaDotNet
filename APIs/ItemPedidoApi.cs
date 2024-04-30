using Microsoft.EntityFrameworkCore;


public static class ItemPedidoApi{

public static void MapItemPedidoApi(this WebApplication app)
{
    var group = app.MapGroup("/itensPedido");

    group.MapGet("/", async (BancoDeDados db) =>
    {
        return await db.ItensPedido
            .Include(i => i.Pedido)
            .Include(i => i.Pizza)
            .ToListAsync();
    });

    group.MapPost("/", async (ItemPedido itemPedido, BancoDeDados db) =>
    {
        db.ItensPedido.Add(itemPedido);
        await db.SaveChangesAsync();
        return Results.Created($"/itensPedido/{itemPedido.Id}", itemPedido);
    });

    group.MapPut("/{id}", async (int id, ItemPedido updatedItem, BancoDeDados db) =>
    {
        var itemPedido = await db.ItensPedido.FindAsync(id);
        if (itemPedido == null) return Results.NotFound();

        itemPedido.Pizza = updatedItem.Pizza ?? itemPedido.Pizza;
        itemPedido.Valor = updatedItem.Valor ?? itemPedido.Valor;
        itemPedido.Quantidade = updatedItem.Quantidade ?? itemPedido.Quantidade;
        itemPedido.Total = updatedItem.Total ?? itemPedido.Total;

        await db.SaveChangesAsync();
        return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
    {
        var item = await db.ItensPedido.FindAsync(id);
        if (item == null) return Results.NotFound();

        db.ItensPedido.Remove(item);
        await db.SaveChangesAsync();
        return Results.NoContent();
    });
}
}