public class ServiceOrder : BaseEntity
{
    // Ordem de serviço -> Dados do prestador de serviço e da solicitação (e preço)

    public Guid SupplierId { get; set; } //Supplier Supplier
    public Guid ServiceId { get; set; } //Service Service
    // public Guid? ContractId { get; set; }
    public DateTimeOffset EstimetedDate { get; set; }
    public ERequestStatus Status { get; set; }
}