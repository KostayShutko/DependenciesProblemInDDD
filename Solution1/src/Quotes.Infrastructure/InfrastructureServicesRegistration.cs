﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Checks;
using Quotes.Infrastructure.Database;
using Quotes.Infrastructure.Repository;

namespace Quotes.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<QuotesContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IRepository<Quote>, QuotesRepository>();
        services.AddTransient<IIsQuoteNameUniqueCheck, IsQuoteNameUniqueCheck>();

        return services;
    }
}