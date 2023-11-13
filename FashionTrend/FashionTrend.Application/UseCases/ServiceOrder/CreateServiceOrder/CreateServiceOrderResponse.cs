public sealed record CreateServiceOrderResponse
{
    //public Guid Id { get; set; }
    public Guid SupplierId { get; set; } //Supplier Supplier
    public Guid ServiceId { get; set; } //Service Service
    // public Guid? ContractId { get; set; }
    public DateTimeOffset EstimetedDate { get; set; }
    public ERequestStatus Status { get; set; }
}
