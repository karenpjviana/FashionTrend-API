public sealed record GetByMachineSupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Machine { get; set; }
    public List<EMaterial> Materials { get; set; }
    public List<ESewingMachine> SewingMachines { get; set; }
}
