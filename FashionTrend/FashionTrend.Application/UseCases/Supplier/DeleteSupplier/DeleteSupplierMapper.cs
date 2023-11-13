using AutoMapper;
public class DeleteSupplierMapper : Profile
{
    public DeleteSupplierMapper()
    {
        CreateMap<DeleteSupplierRequest, Supplier>();
        CreateMap<Supplier, DeleteSupplierResponse>();
    }
}   