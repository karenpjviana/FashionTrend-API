public class DraftContract : BaseEntity
{
    public ServiceOrder ServiceOrder { get; set; }
    public string Description { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool Accepted { get; set; }
}
