using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(6, ErrorMessage = "Минимум 6 символов")]
        public string Password { get; set; }
    }
}
