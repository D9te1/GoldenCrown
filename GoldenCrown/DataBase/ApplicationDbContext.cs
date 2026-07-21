using GoldenCrown.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
namespace GoldenCrown.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>()
                .ToTable("users");
            userEntity.HasKey(x => x.Id);
            userEntity.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            userEntity.Property(x => x.Login)
                .HasColumnName("login")
                .IsRequired();
            userEntity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            userEntity.Property(x=>x.Password)
                .HasColumnName("password")
                .IsRequired();
            userEntity.HasData(
                new User
                {
                    Id = 1, Login = "admin", Name = "Administrator", Password = "admin"
                },
                new User
                {
                    Id = 2, Login = "user1", Name = "User1", Password = "user1"
                },
                new User
                {
                    Id = 3, Login = "user2", Name = "User2", Password = "user2"
                }
            );
            var accountEntity = modelBuilder.Entity<Account>()
                .ToTable("account");
            accountEntity.HasKey(x => x.Id);
            accountEntity.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            accountEntity.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            accountEntity.Property(x => x.Balance)
                .HasColumnName("balance")
                .HasPrecision(18,2)
                .IsRequired();
            accountEntity.HasOne<User>()
                .WithOne()
                .HasForeignKey<Account>(x=>x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            var sessionEntity = modelBuilder.Entity<Session>()
                .ToTable("session");
            sessionEntity.HasKey(x => x.UserId);
            sessionEntity.Property(x => x.UserId)
                .HasColumnName("userId")
                .UseIdentityColumn();
            sessionEntity.Property(x => x.Token)
                .HasColumnName("token")
                .IsRequired();
            sessionEntity.Property(x => x.ExpiresAt)
                .HasColumnName("expires_at")
                .IsRequired();
            sessionEntity.HasOne<User>()
                .WithOne()
                .HasForeignKey<Session>(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            var transactionEntity = modelBuilder.Entity<Transaction>()
                .ToTable("transaction");
            transactionEntity.HasKey(x=>x.Id);
            transactionEntity.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            transactionEntity.Property(x=>x.SenderAccountId)
                .HasColumnName("sender_account_id")
                .IsRequired();
            transactionEntity.Property(x => x.ReceiverAccountId)
                .HasColumnName("receiver_account_id")
                .IsRequired();
            transactionEntity.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            transactionEntity.Property(x=>x.Amount)
                .HasColumnName("amount")
                .HasPrecision(18,2)
                .IsRequired();
            transactionEntity.HasOne<User>()
                .WithMany()
                .HasForeignKey(x=>x.SenderAccountId)
                .OnDelete(DeleteBehavior.NoAction);
            transactionEntity.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.ReceiverAccountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
