using Microsoft.EntityFrameworkCore;

namespace Template.Project.Domain.RepositoriesContracts.IBase
{
    public interface ISystemContext
    {
        DbContext Db { get; set; }
    }
}
