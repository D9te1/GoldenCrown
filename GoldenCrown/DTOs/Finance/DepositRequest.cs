using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs.Finance
{
    public class DepositRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Token {  get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Больше 0")]
        public decimal Amount { get; set; }
    }
}
