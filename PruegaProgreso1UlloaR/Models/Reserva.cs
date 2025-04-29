using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruegaProgreso1UlloaR.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        public double Pagar { get; set; }
        public string ClienteIdentificacion { get; set; }

        [ForeignKey ("ClienteIdentificacion")]
        public Cliente? Cliente { get; set; }

    }
}
