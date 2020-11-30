using DeveloperChallenge.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperChallenge.Infra.Repositories.Maps
{
    public class OfxFileMap : IEntityTypeConfiguration<OfxFile>
    {
        public void Configure(EntityTypeBuilder<OfxFile> builder)
        {
            builder.ToTable("OFX_FILE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .IsRequired();
            builder.Property(c => c.BankId)
                .HasColumnName("BANK_ID");
            builder.Property(c => c.Language)
                .HasColumnName("LANGUAGE");
            builder.Property(c => c.FileCreation)
                .HasColumnName("FILE_CREATION_DT");
            builder.Property(c => c.TrNuId)
                .HasColumnName("TR_NU_ID");
            builder.Property(c => c.IntervalStart)
                .HasColumnName("INTERVAL_START_DT")
                .HasColumnType("DATETIME");
            builder.Property(c => c.IntervalEnd)
                .HasColumnName("INTERVAL_END_DT")
                .HasColumnType("DATETIME");
            builder.Property(c => c.CreatedAt)
                .HasColumnName("CREATED_AT_DT")
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}