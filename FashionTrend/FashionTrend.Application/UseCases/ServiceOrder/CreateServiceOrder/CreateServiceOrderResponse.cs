﻿public sealed record CreateServiceOrderResponse
{
    public Guid Id { get; set; }
    public Supplier Supplier { get; set; }
    public Service Service { get; set; }
    public DateTimeOffset EstimetedDate { get; set; }
    public ERequestStatus Status { get; set; }
    public bool Payment { get; set; }
}
