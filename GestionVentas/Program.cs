using GestionVentas.Infraestructura;
using GestionVentas.Services;

public class Program()
{
    static void Main(string[] args)
    {
        var cargar = new CargarArchivosCSV();
        var clientes = cargar.CargarClientes();
        var ventas = cargar.CargarVentas();

        var consultas = new ConsultasVentasService();
        var ventasMesAnioActual = consultas.ObtenerVentasMesAnioActual(clientes, ventas);

        Console.WriteLine("Ventas en el mes y anio actual: ");
        foreach (var item in ventasMesAnioActual)
        {
            Console.WriteLine("----- Cliente -----");
            Console.WriteLine($"Nombre: {item.NombreCliente}");
            Console.WriteLine($"Email: {item.Email}");
            Console.WriteLine($"Categoria: {item.Categoria}");
            Console.WriteLine($"Total Ventas del Mes: {item.CantidadVentas}");
            Console.WriteLine($"Total Facturado: ${item.TotalVendido}");
            Console.WriteLine();
        }

        var clientesSinVentasMesActual = consultas.ObtenerClientesSinVentasEnElMesActual(clientes, ventas);

        Console.WriteLine("Clientes sin ventas en el mes y anio actual: ");
        foreach (var item in clientesSinVentasMesActual)
        {
            Console.WriteLine("----- Cliente -----");
            Console.WriteLine($"Nombre: {item.Nombre}");
            Console.WriteLine($"Email: {item.Email}");
            Console.WriteLine($"Categoria: {item.Categoria}");
            Console.WriteLine();
        }

        var rankingDeClientes = consultas.ObtenerRankingClientes(clientes, ventas);
        
        Console.WriteLine("Ranking de monto de ventas de clientes: ");
        foreach (var item in rankingDeClientes)
        {
            Console.WriteLine("----- Cliente -----");
            Console.WriteLine($"Nombre: {item.NombreCliente}");
            Console.WriteLine($"Email: {item.Email}");
            Console.WriteLine($"Categoria: {item.Categoria}");
            Console.WriteLine($"Total Ventas del Mes: {item.CantidadVentas}");
            Console.WriteLine($"Total Facturado: ${item.TotalVendido}");
            Console.WriteLine();
        }

        var facturacionPorCategoria = consultas.ObtenerTotalFacturadoPorCategoria(clientes, ventas);

        Console.WriteLine("Facturacion del mes actual por categoria: ");
        foreach (var item in facturacionPorCategoria)
        {
            Console.WriteLine($"Nombre: {item.Categoria}");
            Console.WriteLine($"Total Facturado: ${item.MontoTotalPorCategoria}");
            Console.WriteLine();
        }
    }
}