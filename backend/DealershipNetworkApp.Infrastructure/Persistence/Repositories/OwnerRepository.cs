using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : BaseRepository<OwnerInputModel, Owner>, IOwnerRepository
    {
        public OwnerRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Owner> GetByCpfCnpj(string cpfCnpj)
                => await _context.Owners.FindAsync(cpfCnpj);

        public async Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj)
        {
            var entity = await GetByCpfCnpj(cpfCnpj);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);

            _context.Owners.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
