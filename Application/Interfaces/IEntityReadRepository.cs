using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEntityReadRepository<TEnity> where TEnity : BaseEntity
    {
        Task<TEnity> GetByIdAsync(Guid id);
        Task<TEnity> GetAsync(Expression<Func<TEnity, bool>> predicate);
        Task<TResult> GetAsync<TResult>(string sqlCommand, object param);
        Task<TResult> GetAsync<TResult>(Expression<Func<TEnity, bool>> predicate,Expression<Func<TEnity,TResult>> selector);
        Task<TResult> GetAsync<TResult>(Expression<Func<TEnity,bool>> predicate,Expression<Func<TEnity,TResult>> selector,params Expression<Func<TEnity,object>>[] includes);

        Task<IEnumerable<TEnity>> GetListAsync(Expression<Func<TEnity, bool>> predicate = null);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEnity, bool>> predicate, Expression<Func<TEnity, TResult>> selector);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEnity, bool>> predicate, Expression<Func<TEnity, TResult>> selector, params Expression<Func<TEnity, object>>[] includes);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(string sqlCommand, object param);
        

        Task<int> CountAsync(Expression<Func<TEnity, bool>> predicate);
        Task<int> CountAsync(string sqlCommand, object param);
        Task<bool> AnyAsnc(Expression<Func<TEnity, bool>> predicate);
        Task<bool> AnyAsync(string sqlCommand, object param);
        Task<int> ExecuteAsync(string command, params object[] paramaters);
    }
}
