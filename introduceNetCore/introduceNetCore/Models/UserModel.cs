using System.ComponentModel.DataAnnotations;

namespace introduceNetCore.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "İsminizi girmeyi unutmayın!")]
        [MaxLength(30, ErrorMessage = "En fazla 30 karakter olabilir!")]
        [MinLength(2, ErrorMessage = "En az iki harf...")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Eposta adresini girmeyi unutmayın!")]
        public string Email { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }

    }
}
