public sealed record GetSupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<EMaterial> Materials { get; set; }
    public List<ESewingMachine> SewingMachines { get; set; }
}
