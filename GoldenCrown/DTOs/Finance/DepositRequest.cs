using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs.Finance
{
    public class DepositRequest
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Больше 0")]
        public decimal Amount { get; set; }
    }
}
