public sealed record GetBySupplierIdServiceOrderResponse
{
    public Guid Id { get; set; }
    public Supplier Supplier { get; set; }
    public ServiceOrder ServiceOrder { get; set; }
    public DateTimeOffset EstimetedDate { get; set; }
    public ERequestStatus Status { get; set; }
    public bool Payment { get; set; }
}
