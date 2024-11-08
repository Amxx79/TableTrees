using TableTree.Data.Models;

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
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<TreeType>> GetAllTreeTypesAsync();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<TreeType> GetAllTreeTypes();

        //Add methods
        bool Add(TType item);
        Task<bool> AddAsync(TType item);
        void AddRange(TType[] items);
        void AddRangeAsync(TType[] items);

        //Update methods
        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);

        //Delete methods
        bool Delete(TType item);

        //Save methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
