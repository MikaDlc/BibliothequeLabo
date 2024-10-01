using DAL = DAL_Bibliotheque;
using BLL = BLL_Bibliotheque;
using Commun_Bibliotheque.Repositories;
using EF_Bibliotheque;

namespace API_Bibliotheque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddScoped<IBookRepository<DAL.Entities.Book>, DAL.Services.BookService>();
            builder.Services.AddScoped<IBookRepository<BLL.Entities.Book>, BLL.Services.BookService>();
            builder.Services.AddScoped<IAuthorRepository<DAL.Entities.Author>, DAL.Services.AuthorService>();
            builder.Services.AddScoped<IAuthorRepository<BLL.Entities.Author>, BLL.Services.AuthorService>();
            builder.Services.AddScoped<IClientRepository<DAL.Entities.Client>, DAL.Services.ClientService>();
            builder.Services.AddScoped<IClientRepository<BLL.Entities.Client>, BLL.Services.ClientService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
