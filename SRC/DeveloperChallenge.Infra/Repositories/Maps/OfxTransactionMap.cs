using DeveloperChallenge.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperChallenge.Infra.Repositories.Maps
{
    public class OfxTransactionMap : IEntityTypeConfiguration<OfxTransaction>
    {
        public void Configure(EntityTypeBuilder<OfxTransaction> builder)
        {
            builder.ToTable("OFX_TRANSACTION");
            builder.HasKey(t => t.Id);

            builder.HasOne<OfxFile>()
                .WithMany(c => c.Transactions)
                .HasForeignKey(c => c.OfxFileId);

            builder.Property(c => c.OfxFileId)
                .HasColumnName("OFX_FILE_ID")
                .IsRequired();
            builder.Property(c => c.TransactionDate)
                .HasColumnName("TRANSACTION_DT")
                .HasColumnType("DATETIME");
            builder.Property(c => c.EntryType)
                .HasColumnName("ENTRY_TYPE")
                .HasColumnType("INT");
            builder.Property(c => c.Value)
                .HasColumnName("VALUE")
                .HasColumnType("NUMERIC(20,2)");
            builder.Property(c => c.Description)
                .HasColumnName("DESCRIPTION");
            builder.Property(c => c.DuplicationOfTransactionId)
                .HasColumnName("DUP_OF_TRANSACTION_ID");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("CREATED_AT_DT")
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}