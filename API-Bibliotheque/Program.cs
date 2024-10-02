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
            builder.Services.AddScoped<IGenreRepository<DAL.Entities.Genre>, DAL.Services.GenreService>();
            builder.Services.AddScoped<IGenreRepository<BLL.Entities.Genre>, BLL.Services.GenreService>();
            builder.Services.AddScoped<ILeaseRepository<DAL.Entities.Lease>, DAL.Services.LeaseService>();
            builder.Services.AddScoped<ILeaseRepository<BLL.Entities.Lease>, BLL.Services.LeaseService>();
            builder.Services.AddScoped<ISaleRepository<DAL.Entities.Sale>, DAL.Services.SaleService>();
            builder.Services.AddScoped<ISaleRepository<BLL.Entities.Sale>, BLL.Services.SaleService>();
            builder.Services.AddScoped<ILibraryRepository<DAL.Entities.Library>, DAL.Services.LibraryService>();
            builder.Services.AddScoped<ILibraryRepository<BLL.Entities.Library>, BLL.Services.LibraryService>();

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
