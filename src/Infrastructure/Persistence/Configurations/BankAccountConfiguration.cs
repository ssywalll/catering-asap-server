using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(n => n.Bank_Number)
         .HasMaxLength(25);
        builder.Property(a => a.Name)
         .HasMaxLength(50);

        builder
              .HasOne(t => t.Users)
              .WithMany(c => c.BankAccounts)
              .HasForeignKey(t => t.User_Id)
              .HasConstraintName("Fk_BankAccount_User")
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();
    }
}
