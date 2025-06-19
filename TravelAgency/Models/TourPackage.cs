using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace TravelAgency.Models
{
    public class TourPackage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [MinLength(5, ErrorMessage = "O título deve ter pelo menos 5 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Data de início é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "A capacidade máxima é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade máxima deve ser maior que 0")]
        public int MaxCapacity { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public List<Destination> Destinations { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();
    }
}
