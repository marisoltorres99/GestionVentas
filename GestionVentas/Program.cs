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
    }
}