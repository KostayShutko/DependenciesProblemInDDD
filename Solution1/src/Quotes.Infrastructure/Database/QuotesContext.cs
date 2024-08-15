using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Database.EntityTypeConfigurations;

namespace Quotes.Infrastructure.Database;

public class QuotesContext : DbContext
{
    public QuotesContext(DbContextOptions<QuotesContext> options)
        : base(options)
    { 
    }

    public DbSet<Quote>? Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new QuotesEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new QuoteItemConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
