using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTree.Data.Repository.Interfaces
{
    public interface IRepository<TType>
    {
        //GET Methods
        TType GetById(Guid Id);
        Task<TType> GetByIdAsync(Guid Id);
        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();
        IQueryable<TType> GetAllAttached();

        //Add methods
        bool Add(TType item);
        Task<bool> AddAsync(TType item);
        void AddRange(TType[] items);
        void AddRangeAsync(TType[] items);
        bool Delete(TType item);

        //Update methods
        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);
    }
}
