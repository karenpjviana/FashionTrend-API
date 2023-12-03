public class Contract : BaseEntity 
{
    public Guid OrderId { get; set; } //Order Order
    public Guid SupplierId { get; set; } //Supplier Supplier
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public EContractStatus Status { get; set; }
}
