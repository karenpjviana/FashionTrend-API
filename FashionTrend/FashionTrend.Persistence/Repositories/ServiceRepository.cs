using Microsoft.EntityFrameworkCore;

public class ServiceRepository :  BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Service>> GetByDescription(string description, CancellationToken cancellationToken)
    {
        return await Context.Services.Where(x => x.Description.Equals(description)).ToListAsync(cancellationToken);
    }

    public async Task<List<Service>> GetByType(string type, CancellationToken cancellationToken)
    {
        return await Context.Services.Where(x => x.Type.Equals(type)).ToListAsync(cancellationToken);
    }
}
