using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Project.Domain.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Template.Project.Infrastructure.DBContext.ModelBaseConfiguration
{
    public class TemplateConfiguration : IEntityTypeConfiguration<TemplateEntity>
    {
        public void Configure(EntityTypeBuilder<TemplateEntity> builder)
        {
            builder.HasKey(x => x.Guid);           
        }
    }
}
