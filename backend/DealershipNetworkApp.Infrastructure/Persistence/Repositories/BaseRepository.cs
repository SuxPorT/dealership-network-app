﻿using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntityInputModel, TEntity> : IBaseRepository<TEntityInputModel, TEntity> 
        where TEntityInputModel : BaseInputModel
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<TEntity> GetById(int id);

        public async Task<IList<TEntity>> GetAll()
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> Add(TEntityInputModel inputModel)
        {
            var entity = _mapper.Map<TEntity>(inputModel);

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntityInputModel inputModel, int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
