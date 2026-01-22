using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Infrastructure.Database.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_User_Email_Format", "Email LIKE '%_@%_.%_'"));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Role)
            .HasDefaultValue(UserRole.User);

        builder.Property(u => u.Lastname)
            .HasMaxLength(100);

        builder.Property(u => u.Firstname)
            .HasMaxLength(100);

        builder.HasMany(u => u.Todos)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
