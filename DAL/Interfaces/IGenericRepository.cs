using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Dapper;

namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
      {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(int Id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int Id);
    }
}
