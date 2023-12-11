using System.Linq.Expressions;

namespace MagicVilla_VillaApi.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllVillasAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetVillaAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task CreateAsync(T entity);

        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
