using GestionVentas.Model;

namespace GestionVentas.Services
{
    public class FacturacionPorCategoriaDTO
    {
        public Categoria Categoria { get; set; }
        public decimal MontoTotalPorCategoria { get; set; }
    }
}
