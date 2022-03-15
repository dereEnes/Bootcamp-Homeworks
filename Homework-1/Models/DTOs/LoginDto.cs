using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkOne.Models.Entities
{
    public class LoginDto
    {
        [Display(Order = 1, Name = "İsim")]
        [Required(ErrorMessage = "İsim alanı girilmelidir!")]
        [RegularExpression("^[a-zA-Z]*$",
            ErrorMessage = "Lütfen sadece harf giriniz!")]
        public string Name { get; set; }

        [Display(Order = 2, Name = "Soyisim")]
        [Required(ErrorMessage = "Soyisim alanı girilmelidir!")]
        [RegularExpression("^[a-zA-Z]*$",
            ErrorMessage = "Lütfen sadece harf giriniz!")]
        public string Surname { get; set; }

        [Display(Order = 3, Name = "Email adresi")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
            ErrorMessage = "Geçerli bir email adresi giriniz!")]
        [Required(ErrorMessage = "Email alanını girilmelidir!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Order = 4, Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı girilmelidir!")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
            ErrorMessage = "Şifreniz en az 8 karakter, 1 büyük harf, 1 karakter ve 1 sayı içermelidir!")]
        public string Password { get; set; }
    }
}
