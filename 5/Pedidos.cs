public class PedidoService
{
    private readonly ApplicationDbContext _context;

    public PedidoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Pedido> ObtenerPedidosPorValor(decimal valorMinimo)
    {
        var pedidos = _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Productos)
            .Where(p => p.Total > valorMinimo)
            .ToList();

        return pedidos;
    }
}