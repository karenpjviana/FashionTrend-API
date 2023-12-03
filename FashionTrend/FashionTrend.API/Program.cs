using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FashionTrend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigurePersistenceApp(builder.Configuration);
            
            builder.Services.ConfigureApplicationApp();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
            });
            
            builder.Services.AddSwaggerGen(options =>
            {
                var openApiInfo = new OpenApiInfo();

                openApiInfo.Title = "API FashionTrend - Grupo de Sustentabilidade";
                openApiInfo.Description = "Documentação da API FashionTrend para o módulo de Arquitetura de software 2 do Grupo de Sustentabilidade, oferece a funcionalidade para costureiras(fornecedores) se cadastrarem e acessarem oportunidades de serviço disponibilizadas pela Fashion Trend.";

                openApiInfo.Contact = new OpenApiContact()
                {
                    Name = "Turma 1038"
                };

                options.SwaggerDoc("v1", openApiInfo);

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var path = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(path, true);
            });

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.ConfigureCorsPolicy();

            var app = builder.Build();

            BD.CreateDataBase(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}