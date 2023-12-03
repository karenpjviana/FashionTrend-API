using AutoMapper;
public class GetByMachineSupplierMapper : Profile
{
    public GetByMachineSupplierMapper()
    {
        CreateMap<Supplier, GetByMachineSupplierResponse>();
    }
}   