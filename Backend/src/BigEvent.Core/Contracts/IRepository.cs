using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigEvent.Core.Contracts
{
    public interface IRepository
    {

        // General Methods
        Task AddAsync<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(IEnumerable<T> entity) where T : class;

        Task<bool> SaveChangesAsync();

    }
}