using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public List<Reservation> Reservations { get; set; } = new();

        public bool IsDeleted { get; set; } = false;
    }
}
