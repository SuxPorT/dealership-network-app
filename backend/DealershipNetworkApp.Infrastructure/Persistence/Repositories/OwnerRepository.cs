using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public OwnerRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<Owner>> GetAll()
            => await _context.Owners.ToListAsync();

        public async Task<Owner> GetByCpfCnpj(string cpfCnpj)
                => await _context.Owners.FindAsync(cpfCnpj);

        public async Task<Owner> Add(OwnerInputModel inputModel)
        {
            var entity = _mapper.Map<Owner>(inputModel);

            _context.Owners.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

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

        public async Task<Owner> RemoveByCpfCnpj(Owner owner)
        {
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return owner;
        }
    }
}
