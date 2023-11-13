public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public Guid ContractId { get; set; }
}
