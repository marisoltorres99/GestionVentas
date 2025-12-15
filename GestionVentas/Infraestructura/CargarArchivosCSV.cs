using GestionVentas.Model;

namespace GestionVentas.Infraestructura
{
    public class CargarArchivosCSV
    {
        private readonly string rutaClientes = @"Data\clientes.csv";
        private readonly string rutaVentas = @"Data\ventas.csv";

        public List<Cliente> CargarClientes()
        {
            var clientes = new List<Cliente>();
            var lineas = File.ReadAllLines(rutaClientes);
            for (int i = 0; i < lineas.Length; i++)
            {
                var partes = lineas[i].Split(',');
                var cliente = new Cliente();
                cliente.IdCliente = int.Parse(partes[0]);
                cliente.Nombre = partes[1];
                cliente.Email = partes[2];
                cliente.Categoria = Enum.Parse<Categoria>(partes[3]);
                clientes.Add(cliente);
            }
            return clientes;
        }

        public List<Venta> CargarVentas()
        {
            var ventas = new List<Venta>();
            var lineas = File.ReadAllLines(rutaVentas);
            for (int i = 0; i < lineas.Length; i++)
            {
                var partes = lineas[i].Split(',');
                var venta = new Venta();
                venta.IdCliente = int.Parse(partes[0]);
                venta.Monto = decimal.Parse(partes[1]);
                venta.Fecha = DateTime.Parse(partes[2]);
                ventas.Add(venta);
            }
            return ventas;
        }
    }
}
