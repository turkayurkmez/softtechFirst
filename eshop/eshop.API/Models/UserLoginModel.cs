using System.ComponentModel.DataAnnotations;

namespace eshop.API.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı neden boş? Yıl 2023 hala....")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifreyi de girin bir zahmet")]
        public string Password { get; set; }
    }
}
