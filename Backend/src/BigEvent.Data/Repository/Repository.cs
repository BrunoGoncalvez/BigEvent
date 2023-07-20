using System.Collections.Generic;
using System.Threading.Tasks;

using BigEvent.Core.Contracts;
using BigEvent.Data.Context;

namespace BigEvent.Data.Repository
{
    public class Repository : IRepository
    {

        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            this._context = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await this._context.AddAsync(entity);
        }
      
        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        } 

        public void DeleteRange<T>(IEnumerable<T> entity) where T : class
        {
            this._context.RemoveRange(entity);
        } 
        
        public async Task<bool> SaveChangesAsync()
        {
            // Salvar as alterações no contexto
            int rowsAffected = await _context.SaveChangesAsync();

            // Verificar se houve alguma entidade afetada pelas alterações
            bool success = rowsAffected > 0;

            return success;
        } 
    }
}