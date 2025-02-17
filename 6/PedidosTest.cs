
[TestFixture]
public class PedidosTests
{
    private Mock<ApplicationDbContext> _contextMock;
    private PedidoService _pedidoService;
    private List<Pedido> _pedidosFake;

    [SetUp]
    public void Setup()
    {
        // Datos de prueba
         _pedidosTest = new List<Pedido>
        {
            new Pedido { Id = 1, Total = 100, Cliente = new Cliente(), Productos = new List<Producto>() },
            new Pedido { Id = 2, Total = 200, Cliente = new Cliente(), Productos = new List<Producto>() },
            new Pedido { Id = 3, Total = 300, Cliente = new Cliente(), Productos = new List<Producto>() }
        };

        var pedidosDbSetMock =  _pedidosTest.AsQueryable().BuildMockDbSet();
        _contextMock = new Mock<ApplicationDbContext>();
        _contextMock.Setup(c => c.Pedidos).Returns(pedidosDbSetMock.Object);

        _pedidoService = new PedidoService(_contextMock.Object);
    }

    [Test]
    public void ObtenerPedidosPorValor_CuandoValorMinimoEs150_DeberiaDevolverDosPedidos()
    {
        // Arrange
        decimal valorMinimo = 150;

        // Act
        var resultado = _pedidoService.ObtenerPedidosPorValor(valorMinimo);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultado.Count, Is.EqualTo(2));
            Assert.That(resultado.All(p => p.Total > valorMinimo), Is.True);
        });
    }
}