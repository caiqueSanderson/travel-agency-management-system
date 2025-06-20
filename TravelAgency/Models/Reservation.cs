using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public int TourPackageId { get; set; }
        public TourPackage TourPackage { get; set; }

        [Required(ErrorMessage = "Data de reserva é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
