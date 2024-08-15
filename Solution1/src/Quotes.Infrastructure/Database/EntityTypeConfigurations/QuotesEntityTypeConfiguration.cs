using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Database.Converters;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Infrastructure.Database.EntityTypeConfigurations;

public class QuotesEntityTypeConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.HasKey(quote => quote.Id);

        builder.Property(quote => quote.Id)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quote => quote.Name)
            .HasConversion<ValueObjectConverter<Title, string>>();

        builder.Property(quote => quote.CustomerId)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quote => quote.CompanyId)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quote => quote.ConsultantId)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quote => quote.Status);

        builder.Property(quote => quote.Discount)
            .HasConversion<ValueObjectConverter<Discount, decimal>>();

        builder.Property(quote => quote.TotalCost)
            .HasConversion<ValueObjectConverter<Cost, decimal>>();

        builder.Property(quote => quote.TotalCostWithTaxes)
            .HasConversion<ValueObjectConverter<Cost, decimal>>();

        builder
            .HasOne(payment => payment.Payment)
            .WithOne()
            .HasForeignKey<Payment>(payment => payment.QuoteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(quote => quote.QuoteItems)
            .WithOne()
            .HasForeignKey(quoteItem => quoteItem.QuoteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
