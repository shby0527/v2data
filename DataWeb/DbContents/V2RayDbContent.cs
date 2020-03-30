using DataWeb.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DataWeb.DbContents
{
    public class V2RayDbContent : DbContext
    {
        public V2RayDbContent(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<DataEntity> DataEntity { get; set; }

        public virtual DbSet<AdminUser> AdminUsers { get; set; }

        public virtual DbSet<ServerInfo> ServerInfos { get; set; }

        public virtual DbSet<AdminSms> AdminSms { get; set; }

        public virtual DbSet<V2ServerUser> ServerUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntity>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            modelBuilder.Entity<AdminUser>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            modelBuilder.Entity<ServerInfo>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            modelBuilder.Entity<AdminSms>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            modelBuilder.Entity<V2ServerUser>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            modelBuilder.Entity<AdminUser>()
                .HasMany(e => e.Servers)
                .WithOne(e => e.Admin)
                .HasForeignKey(e => e.AdminId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<AdminUser>()
                .HasMany(e => e.Sms)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.AdminId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<ServerInfo>()
                .HasMany(e => e.ServerUsers)
                .WithOne(e => e.Server)
                .HasForeignKey(e => e.ServerId)
                .HasPrincipalKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
