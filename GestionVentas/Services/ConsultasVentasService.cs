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

        public List<VentasPorClienteDTO> ObtenerRankingClientes(List<Cliente> clientes, List<Venta> ventas)
        {
            var rankingVentasClientes = from c in clientes
                                        join v in ventas on c.IdCliente equals v.IdCliente
                                        where (v.Fecha.Month == DateTime.Now.Month) && (v.Fecha.Year == DateTime.Now.Year)
                                        group v by new { c.Nombre, c.Email, c.Categoria, c.IdCliente } into grupo
                                        orderby grupo.Sum(v => v.Monto) descending
                                        select new VentasPorClienteDTO
                                        {
                                            NombreCliente = grupo.Key.Nombre,
                                            Email = grupo.Key.Email,
                                            Categoria = grupo.Key.Categoria,
                                            TotalVendido = grupo.Sum(v => v.Monto),
                                            CantidadVentas = grupo.Count()
                                        };
            return rankingVentasClientes.Take(3).ToList();
        }

        public List<FacturacionPorCategoriaDTO> ObtenerTotalFacturadoPorCategoria(List<Cliente> clientes, List<Venta> ventas)
        {
            var facturacionPorCategoria = from c in clientes
                                          join v in ventas on c.IdCliente equals v.IdCliente
                                          where (v.Fecha.Month == DateTime.Now.Month) && (v.Fecha.Year == DateTime.Now.Year)
                                          group v by new { c.Categoria } into grupo
                                          select new FacturacionPorCategoriaDTO
                                          {
                                              Categoria = grupo.Key.Categoria,
                                              MontoTotalPorCategoria = grupo.Sum(v => v.Monto)
                                          };
            return facturacionPorCategoria.ToList();
        }
        
        public ClienteConVentaMasAltaDTO ObtenerClienteConVentaMasAlta(List<Cliente> clientes, List<Venta> ventas)
        {
            var clienteVentaMasAlta = from v in ventas
                                      join c in clientes on v.IdCliente equals c.IdCliente
                                      where (v.Fecha.Month == DateTime.Now.Month) && (v.Fecha.Year == DateTime.Now.Year)
                                      orderby v.Monto descending
                                      select new ClienteConVentaMasAltaDTO
                                      {
                                          NombreCliente = c.Nombre,
                                          FechaVenta = v.Fecha,
                                          MontoVenta = v.Monto
                                      };
            return clienteVentaMasAlta.FirstOrDefault();
        }
    }
}
