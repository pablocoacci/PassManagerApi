using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EF.EntityTypeConfigurations
{
    public class PasswordSiteEntityTypeConfiguration : IEntityTypeConfiguration<PasswordSite>
    {
        public void Configure(EntityTypeBuilder<PasswordSite> builder)
        {
            builder.ToTable("PasswordSites");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NameSite)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(x => x.URLSite)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(x => x.DescriptionSite)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(700);

            builder.Property(x => x.UserNameSite)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(x => x.SecretAnswer)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(500);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
