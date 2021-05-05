using Template.Project.Domain.Models.Base;
using System;

namespace Template.Project.Domain.Domain.Models
{
    public class TemplateEntity : IBaseEntity
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }
    }
}
