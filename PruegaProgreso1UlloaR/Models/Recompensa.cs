using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruegaProgreso1UlloaR.Models
{
    public class Recompensa
    {
        [Key]
        public int Id { get; set; } // ID de la recompensa

        [MaxLength(100)]
        public string Nombre { get; set; } // Nombre de la recompensa

        public DateTime FechaInicio { get; set; } // Fecha de inicio de la recompensa

        public int PuntosAcumulados { get; set; } // Puntos acumulados por el cliente

        public string TipoRecompensa { get; set; } // Tipo de recompensa (SILVER o GOLD)

        // Un FK para referenciar al cliente que recibe la recompensa
        [ForeignKey("ClienteIdentificacion")]
        public string ClienteIdentificacion { get; set; }

        // Relacion de navegación con Cliente
        public Cliente Cliente { get; set; }

        // Constructor por defecto
        public Recompensa()
        {
            TipoRecompensa = DeterminarTipoRecompensa(PuntosAcumulados); // Asignar tipo de recompensa al momento de crear
        }

        // Método para determinar el tipo de recompensa
        public string DeterminarTipoRecompensa(int puntos)
        {
            return puntos < 500 ? "SILVER" : "GOLD"; // SILVER si los puntos son menos de 500, GOLD si son más de 500
        }

        // Metodo para acumular puntos cuando se realiza una reserva
        public void AcumularPuntos(int puntos)
        {
            PuntosAcumulados += puntos;
            TipoRecompensa = DeterminarTipoRecompensa(PuntosAcumulados); // Actualiza el tipo de recompensa
        }
    }
}
