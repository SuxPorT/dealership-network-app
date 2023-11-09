using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class PhoneRepository : BaseRepository<PhoneInputModel, Phone>, IPhoneRepository
    {
        public PhoneRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<Phone> GetById(int id)
            => await _context.Phones.FirstOrDefaultAsync(e => e.Id == id);
    }
}
