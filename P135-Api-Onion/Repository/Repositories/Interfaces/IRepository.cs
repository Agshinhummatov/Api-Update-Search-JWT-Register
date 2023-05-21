using Domain.Common;
using Domain.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
       
        Task<T> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task <IEnumerable<T>> FindAllAsync(Expression<Func<T,bool>> expression = null);
        Task SoftDeleteAsync(int? id);


    }
}
