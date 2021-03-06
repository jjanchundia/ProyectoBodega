using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAO.DAO;
using Microsoft.EntityFrameworkCore;
using DAO.Services;
using Pomelo.EntityFrameworkCore.MySql;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuración para manejo de cadena de conección
            services.AddDbContext<DAO.Datos.BodegaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnDatabase")));
            services.AddDbContext<DAO.Datos.BodegaContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySql")));

            services.AddControllers();
            
            //Aqui se crean las inyecciones 
            services.AddTransient(typeof(IBodega),typeof(BodegaDAO));
            services.AddTransient(typeof(ICategoria), typeof(CategoriaDAO));
            services.AddTransient(typeof(ICliente), typeof(ClienteDAO));
            services.AddTransient(typeof(IProducto), typeof(ProductoDAO));
            services.AddTransient(typeof(IServicio), typeof(ServicioDAO));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
