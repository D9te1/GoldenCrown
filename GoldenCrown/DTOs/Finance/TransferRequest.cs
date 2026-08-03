using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs.Finance
{
    public class TransferRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string ReceiverLogin { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Сумма больше 0")]
        public decimal Amount { get; set; }
    }
}
