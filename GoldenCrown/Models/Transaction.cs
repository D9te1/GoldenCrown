namespace GoldenCrown.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int SenderAccount {  get; set; }
        public int ReceiverAccount {  get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
