namespace DogShow.Modules.DTO.Payment
{

    public class PaymentRequestDto
    {
        public long Amount { get; set; }
        public string Description { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
