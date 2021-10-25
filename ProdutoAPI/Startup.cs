using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Produto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Produto.Infrastructure.Repository;
using ProdutoDomain = Produtos.Domain.Produto;
using Microsoft.OpenApi.Models;
using ProdutoAPI.Application;

namespace ProdutoAPI
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
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddTransient<IProdutoRepository<ProdutoDomain>, ProdutoRepository>();
            services.AddTransient<ProdutoService, ProdutoService>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProdutoAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //var context = app.ApplicationServices.GetService<ApplicationDbContext>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProdutoAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AdicionarDadosTeste(ApplicationDbContext context)
        {
            var testeUsuario1 = new Produtos.Domain.Produto
            {
            CodigoProduto = new Guid(),
            DescricaoProduto = "Produto 1",
            TipoProduto = "Tipo 1",
            DataLancamento = DateTime.Now,
            Valor = 0
            };

            context.Produtos.Add(testeUsuario1); 
           
            context.SaveChanges();
        }
    }
}
