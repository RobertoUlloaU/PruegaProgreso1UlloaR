using System.ComponentModel.DataAnnotations;

namespace PruegaProgreso1UlloaR.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(100)]
        public string Identificacion { get; set; }

        public int Edad { get; set; }

        [MaxLength(100)]
        public string NombreApellido { get; set; }

        public DateTime FechaEntrada { get; set; } = DateTime.Now; // Se asigna la fecha actual por defecto

        public DateTime? FechaSalida { get; set; } // Se permite que sea nullable para que el usuario la asigne después

        // Relación uno a muchos entre Cliente y Reserva
        public ICollection<Reserva> Reservas { get; set; } // Un cliente puede tener muchas reservas

        // Relación uno a muchos entre Cliente y Recompensa
        public ICollection<Recompensa> Recompensas { get; set; } // Un cliente puede tener muchas recompensas
    }
}
