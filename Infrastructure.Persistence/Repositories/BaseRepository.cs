using Application.Interfaces;
using Domain;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : ReadRepository<TEntity>, IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbConnection _sqlConnection;
        public BaseRepository(ApplicationDbContext sqlConnection) : base(sqlConnection)
        {
            _sqlConnection = _context.Database.GetDbConnection();
        }
        public async Task AddAsync(TEntity entity) => await _entity.AddAsync(entity);
        public async Task AddAsync(IEnumerable<TEntity> entities)=> await _entity.AddRangeAsync(entities);
        public void Delete(Guid id)
        {
            var entity = _entity.Find(id);
            if(entity != null) _entity.Remove(entity);  
        }
        public void Delete(IEnumerable<TEntity> entities)=> _entity.RemoveRange(entities);
        public async  Task<int> SaveChangeAsync()
        {
            int result = 0;
            using (await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                }
                catch (Exception ex )
                {
                    if (_context.Database.CurrentTransaction != null)
                        await _context.Database.RollbackTransactionAsync();
                   
                }
            }
            return result;
        }
        public void Update(TEntity entity)=> _entity.Update(entity);
        public void Update(IEnumerable<TEntity> entities) => _entity.UpdateRange(entities);  
    }
}
