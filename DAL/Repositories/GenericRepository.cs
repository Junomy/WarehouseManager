using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using DAL.Interfaces.EntityInterfaces;
namespace DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<TEntity> entities;
        string errorMessage = string.Empty;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Get() => await entities.ToListAsync();

        public async Task<TEntity> Get(int Id) => await entities.FindAsync(Id);

        public async Task<TEntity> Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity is null");
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity is null");
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<TEntity> Delete(int Id)
        {
            TEntity entity = await entities.FindAsync(Id);
            if (entity == null) throw new ArgumentException("entity is null");
            entities.Remove(entity);
            return entity;
        }
    }
}
