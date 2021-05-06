using Template.Project.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Template.Project.Domain.RepositoriesContracts.IBase
{
    public interface IBaseRepository<T, Key> where T : IBaseEntity
    {
        Task<T> AddAsync(T source);

        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> source);

        Task<bool> DeleteAsync(Key id);
        
        Task DeleteAllAsync(IEnumerable<T> source);
        
        Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate = null, string[] includes = null);
        
        Task<T> GetByIdAsync(Key id);
        
        Task<T> UpdateAsync(T source);
    }
}
