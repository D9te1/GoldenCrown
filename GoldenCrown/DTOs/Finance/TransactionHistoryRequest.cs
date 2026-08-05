using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs.Finance
{
    public class TransactionHistoryRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Limit больше 0")]
        public int Limit { get; set; }
        [Range (0,int.MaxValue, ErrorMessage = "Offset не отрицательное")]
        public int Offset {  get; set; }
    }
}
