using System;
using System.ComponentModel.DataAnnotations;

namespace PruegaProgreso1UlloaR.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(100)]

        public string Identificacion { get; set; }

        [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100")]

        public int Edad { get; set; }  // Edad del cliente (int)

        [MaxLength(100)]

        public string RobertoUlloa { get; set; }  // Nombre completo del cliente

        [DataType(DataType.Date)]

        public DateTime FechaEntrada { get; set; } = DateTime.Now; // Se asigna la fecha actual

        public DateTime? FechaSalida { get; set; } // Se permite que sea nullable para que el usuario la asigne despues

        [Required(ErrorMessage = "El estado activo es obligatorio")]
        public bool EstadoActivo { get; set; }

        public ICollection<Reserva> Reserva { get; set; } // Un cliente puede tener muchas reservas

        // Relación uno a muchos entre Cliente y Recompensa
        public ICollection<Recompensa> Recompensa { get; set; } // Un cliente puede tener muchas recompensas


    }
}

