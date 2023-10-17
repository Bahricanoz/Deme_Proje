using System.ComponentModel.DataAnnotations;

namespace Deme_Proje.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullancı adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]

        public string Password { get; set; }

    }
}
