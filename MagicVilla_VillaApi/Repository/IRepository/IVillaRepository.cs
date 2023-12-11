using MagicVilla_VillaApi.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaApi.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllVillas(Expression<Func<Villa, bool>> filter = null);
        Task<Villa> GetVilla(Expression<Func<Villa, bool>> filter = null, bool tracked = true);
        Task Create(Villa entity);
        Task Remove(Villa entity);
        Task Save();
    }
}
