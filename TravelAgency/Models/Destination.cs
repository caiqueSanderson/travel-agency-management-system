using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da cidade é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "País é obrigatória")]
        public string Country { get; set; }

        public List<TourPackage> TourPackages { get; set; } = new();
    }
}
