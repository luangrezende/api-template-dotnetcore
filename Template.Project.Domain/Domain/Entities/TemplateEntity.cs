using Template.Project.Domain.Entities.Base;
using System;

namespace Template.Project.Domain.Domain.Entities
{
    public class TemplateEntity : IBaseEntity
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }
    }
}
