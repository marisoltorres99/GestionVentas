using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionVentas.Model
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Categoria Categoria { get; set; }
    }

    public enum Categoria
    {
        Regular,
        Gold,
        Platinum
    }
}
