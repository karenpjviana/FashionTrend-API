public sealed record CreateDraftContractResponse
{
    public Guid Id { get; set; }
    public Supplier Supplier { get; set; }
    public Service Service { get; set; }
    public string Description { get; set; }
    public bool Accepted { get; set; }
}
