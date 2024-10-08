using Catalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog;

internal class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    internal static readonly Guid Catalog1Guid = new Guid("A89F6CD7-4693-457B-9009-02205DBBFE45");
    internal static readonly Guid Catalog2Guid = new Guid("E4FA19BF-6981-4E50-A542-7C9B26E9EC31");
    internal static readonly Guid Catalog3Guid = new Guid("17C61E41-3953-42CD-8F88-D3F698869B35");

    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();
        builder.Property(p => p.Author)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.HasData(GetSampleCatalogData());
    }

    private IEnumerable<Catalog> GetSampleCatalogData()
    {
        string tolkien = "J.R.R. Tolkien";
        yield return new Catalog(Catalog1Guid, "The Fellowship of the Ring", tolkien, 10.99m);
        yield return new Catalog(Catalog2Guid, "The Two Towers", tolkien, 11.99m);
        yield return new Catalog(Catalog3Guid, "The Return of the King", tolkien, 12.99m);
    }
}
