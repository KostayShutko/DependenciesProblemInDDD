using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Entities;

namespace Quotes.Infrastructure.Database;

public class QuotesEntityTypeConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.HasKey(quote => quote.Id);
    }
}
