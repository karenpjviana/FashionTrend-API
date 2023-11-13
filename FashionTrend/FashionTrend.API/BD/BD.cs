public class BD
{
    public static void CreateDataBase(WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();

        var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

        dataContext?.Database.EnsureCreated();
    }
}