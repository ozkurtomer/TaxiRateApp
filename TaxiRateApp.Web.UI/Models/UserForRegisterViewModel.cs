using System.ComponentModel.DataAnnotations;

namespace TaxiRateApp.Web.UI.Models
{
    public class UserForRegisterViewModel
    {
        [Required(ErrorMessage = "Isim alanı zorunludur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur")]
        [StringLength(55, MinimumLength = 5, ErrorMessage = "Kullanıcı adı alanı 5-55 karakter arasında olmalıdır")]
        public string UserUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPassword")]
        public string UserRePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        public bool UserAnonymous { get; set; }
    }
}
