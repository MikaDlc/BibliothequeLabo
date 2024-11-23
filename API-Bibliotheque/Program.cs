using DAL = DAL_Bibliotheque;
using BLL = BLL_Bibliotheque;
using Commun_Bibliotheque.Repositories;
using EF_Bibliotheque;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_Bibliotheque.Tools;

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
            builder.Services.AddScoped<IAuthRepository<DAL.Entities.Auth>, DAL.Services.AuthService>();
            builder.Services.AddScoped<IAuthRepository<BLL.Entities.Auth>, BLL.Services.AuthService>();
            builder.Services.AddScoped<IBookLibraryRepository<DAL.Entities.BookLibrary>, DAL.Services.BookLibraryService>();
            builder.Services.AddScoped<JwtGenerator>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = false,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtGenerator.secretKey)),
                            ValidateLifetime = false,
                            ValidateIssuer = false,
                            ValidIssuer = "monapi.com",
                            ValidateAudience = false,
                        };
                    }
                );

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("adminRequired", policy => policy.RequireRole("Admin"));
                options.AddPolicy("userRequired", policy => policy.RequireAuthenticatedUser());
            });

            //builder.Services.AddCors(options => options.AddPolicy("MyPolicy",
            //    o => o
            //          .WithOrigins("https://localhost:7041", "http://localhost:4200/")
            //          ));
            //.AllowAnyHeader()
                      //.AllowAnyMethod())

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseCors("MyPolicy");

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod());
            app.UseCors(o => o.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.MapControllers();

            app.Run();
        }
    }
}
