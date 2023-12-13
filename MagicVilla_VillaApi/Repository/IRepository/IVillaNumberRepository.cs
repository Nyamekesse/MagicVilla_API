using MagicVilla_VillaApi.Models;

namespace MagicVilla_VillaApi.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        public Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
