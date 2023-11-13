using AutoMapper;
public class UpdateSupplierMapper : Profile
{
    public UpdateSupplierMapper()
    {
        CreateMap<UpdateSupplierRequest, Supplier>();
        CreateMap<Supplier, UpdateSupplierResponse>();
    }
}   