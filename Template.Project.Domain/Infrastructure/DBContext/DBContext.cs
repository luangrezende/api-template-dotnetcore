using Template.Project.Infrastructure.DBContext.ModelBaseConfiguration;
using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Template.Project.Infrastructure.DBContext
{
    public class DBContext : DbContext, ISystemContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Db = this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbContext Db { get; set; }
        public DbSet<TemplateEntity> TemplateEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TemplateConfiguration());
        }
    }
}
