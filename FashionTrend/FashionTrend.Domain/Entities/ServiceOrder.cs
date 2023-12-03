public class ServiceOrder : BaseEntity
{
    // Ordem de serviço -> Dados do prestador de serviço e da solicitação (e preço)

    public Supplier Supplier { get; set; } 
    public Service Service { get; set; }
    public DateTimeOffset EstimetedDate { get; set; }
    public ERequestStatus Status { get; set; } = ERequestStatus.Pending;
    public bool Payment { get; set; } = false;
}