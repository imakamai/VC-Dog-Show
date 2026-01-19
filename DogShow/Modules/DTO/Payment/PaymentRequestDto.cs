namespace DogShow.Modules.DTO.Payment
{

    public class PaymentRequestDto
    {
        public long Amount { get; set; }
        public required string Description { get; set; }
        public required string SuccessUrl { get; set; }
        public required string CancelUrl { get; set; }
        public required string Currency { get; set; }
    }
}
