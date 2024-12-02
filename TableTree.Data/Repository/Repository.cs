using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;

namespace TableTree.Data.Repository
{
    public class Repository<TType> : IRepository<TType>
        where TType : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }

        public bool Add(TType item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();

            if (dbSet.Contains(item))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync(TType item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();

            if (await dbSet.ContainsAsync(item))
            {
                return true;
            }

            return false;
        }

        public void AddRange(TType[] items)
        {
            dbSet.AddRange(items);
            dbContext.SaveChanges();
        }

        public async void AddRangeAsync(TType[] items)
        {
            await dbSet.AddRangeAsync(items);
            await dbContext.SaveChangesAsync();
        }

        public void AddRangeFromList(List<TType> items)
        {
            dbSet.AddRange();
            dbContext.SaveChanges();
        }

        public async Task AddRangeAsyncFromList(List<TType> items)
        {
            await dbSet.AddRangeAsync();
            await dbContext.SaveChangesAsync();
        }
        public bool Delete(TType item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();

            if (!dbSet.Contains(item))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<TType> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return dbSet.AsQueryable();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await this.dbContext
                .Categories
                .ToListAsync();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.dbContext
                .Categories
                .ToList();
        }

        public async Task<IEnumerable<TreeType>> GetAllTreeTypesAsync()
        {
            return await this.dbContext
                .TypeOfTrees
                .ToListAsync();
        }

        public IEnumerable<TreeType> GetAllTreeTypes()
        {
            return this.dbContext
                .TypeOfTrees
                .ToList();
        }

        public TType GetById(Guid Id)
        {
            TType entity = dbSet.Find(Id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(Guid Id)
        {
            TType entity = await dbSet.FindAsync(Id);

            return entity;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }

        public bool Update(TType item)
        {
            try
            {
                dbSet.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                dbSet.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
