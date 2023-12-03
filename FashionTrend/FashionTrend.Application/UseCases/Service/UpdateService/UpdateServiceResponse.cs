public sealed record UpdateServiceResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool Delivery { get; set; }
    public ERequestType Type { get; set; }
    public List<ESewingMachine> SewingMachines { get; set; }
    public List<EMaterial> Materials { get; set; }
    public decimal Price { get; set; }
}
