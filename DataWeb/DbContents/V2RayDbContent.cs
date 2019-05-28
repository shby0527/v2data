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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntity>()
                .Property(e => e.Id)
                .UseMySqlIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
