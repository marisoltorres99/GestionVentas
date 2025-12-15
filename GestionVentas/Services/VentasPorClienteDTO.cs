using GestionVentas.Model;

namespace GestionVentas.Services
{
    public class VentasPorClienteDTO
    {
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public Categoria Categoria { get; set; }
        public decimal TotalVendido { get; set; }
        public int CantidadVentas { get; set; }
    }
}
