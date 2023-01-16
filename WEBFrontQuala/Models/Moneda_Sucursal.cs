using System.ComponentModel;

namespace WEBFrontQuala.Models
{
    public class Moneda_Sucursal
    {
        [DisplayName("Código")]
        public int Codigo { get; set; }

        public string Descripcion { get; set; } = null!;
        [DisplayName("Dirección")]
        public string Direccion { get; set; } = null!;
        [DisplayName("Identificación")]
        public string Identificacion { get; set; } = null!;
        [DisplayName("Moneda")]
        public string Monedadesc { get; set; }

    }
}
