using DevIO.Business.Interfaces;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.API.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        //data
        services.AddDbContext<MeuDbContext>();
        // Scopped é usado para aplicações web a criação de uma instancia ele é utilizada todo o cliclo do request
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        //business
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<ICategoriaService, CategoriaService>();

        return services;
    }
}
