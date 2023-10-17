using System.ComponentModel.DataAnnotations;

namespace Deme_Proje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen isim değerini giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisim değerini giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı değerini giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen email değerini giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre değerini giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifre tekrar değerini giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen şifrelerin eşleştiğinden emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
