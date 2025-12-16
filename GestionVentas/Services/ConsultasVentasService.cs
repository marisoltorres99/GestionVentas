using GestionVentas.Model;

namespace GestionVentas.Services
{
    public class ConsultasVentasService {
        public List<VentasPorClienteDTO> ObtenerVentasMesAnioActual(List<Cliente> clientes, List<Venta> ventas)
        {
            var ventasMesAnioActual = from c in clientes
                                  join v in ventas on c.IdCliente equals v.IdCliente
                                  where (v.Fecha.Month == DateTime.Now.Month) && (v.Fecha.Year == DateTime.Now.Year)
                                  group v by new { c.Nombre, c.Email, c.Categoria, c.IdCliente } into grupo
                                  select new VentasPorClienteDTO
                                  {
                                      NombreCliente = grupo.Key.Nombre,
                                      Email = grupo.Key.Email,
                                      Categoria = grupo.Key.Categoria,
                                      TotalVendido = grupo.Sum(v => v.Monto),
                                      CantidadVentas = grupo.Count()
                                  };
            return ventasMesAnioActual.ToList();
        }

        public List<Cliente> ObtenerClientesSinVentasEnElMesActual(List<Cliente> clientes, List<Venta> ventas)
        {
            var ventasMesActual = from v in ventas
                                  where (v.Fecha.Month == DateTime.Now.Month) && (v.Fecha.Year == DateTime.Now.Year)
                                  select new Venta
                                  {
                                      IdCliente = v.IdCliente,
                                      Fecha = v.Fecha,
                                  };

            var clientesSinVentasMesActual = from c in clientes
                                             join v in ventasMesActual on c.IdCliente equals v.IdCliente into ventasCliente
                                             where !ventasCliente.Any()
                                             select c;
            return clientesSinVentasMesActual.ToList();
        }
    }
}
