using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Domain.Interfaces.Services;
using DeveloperChallenge.Domain.Services;
using DeveloperChallenge.Infra.Repositories;
using DeveloperChallenge.Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperChallenge.Api.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependecies(this IServiceCollection services, IConfiguration configuration) =>
            services
                .RegisterDataBaseDependecies(configuration)
                .RegisterDomainDependecies();

        private static IServiceCollection RegisterDataBaseDependecies(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetValue<string>("ConnectionString")))
                .AddScoped<IOfxFileRepository, OfxFileRepository>()
                .AddScoped<IOfxTransactionRepository, OfxTransactionRepository>();

        private static IServiceCollection RegisterDomainDependecies(this IServiceCollection services) =>
            services
                .AddScoped<IDuplicatedTransactionService, DuplicatedTransactionService>()
                .AddScoped<IImportOfxFileService, ImportOfxFileService>();
    }
}