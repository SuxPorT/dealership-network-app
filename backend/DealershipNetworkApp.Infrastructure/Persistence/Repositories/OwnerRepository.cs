﻿using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : BaseRepository<OwnerInputModel, Owner>, IOwnerRepository
    {
        public OwnerRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
