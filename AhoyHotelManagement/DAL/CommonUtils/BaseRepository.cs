using AhoyHotelManagement.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using X.PagedList;

namespace AhoyHotelManagement.CommonUtils
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void Remove(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        IQueryable<T> Include(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeExpressions);
        Task<IEnumerable<T>> ExcuteQuerys(string query, params object[] parameters);
        public Task<dynamic> ExcuteQuery(string query, params object[] parameters);
        Task<IPagedList<T>> GetPagedList(
           PaginationParameters paginationParameters,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
           );
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected HotelContext context { get; set; }
        protected DbSet<T> DbSet { get; set; }
        public BaseRepository(HotelContext _context)
        {
            this.context = _context;
            DbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await this.DbSet.AddAsync(entity);
        }

        public void UpdateAsync(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.DbSet.AsNoTracking().ToListAsync();
        }
        public IQueryable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression).AsNoTracking().AsQueryable();
        }
        public IQueryable<T> Include(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeExpressions)
        {
            DbSet<T> dbSet = DbSet;
            includeExpressions.ToList().ForEach(x => DbSet.Include(x).Load());
            return DbSet;
        }
        public async Task<IEnumerable<T>> ExcuteQuerys(string query, params object[] parameters)
        {
            return await DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }

        public async Task<dynamic> ExcuteQuery(string query, params object[] parameters)
        {
            return await DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }
        public async Task<IPagedList<T>> GetPagedList(PaginationParameters paginationParameters, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = DbSet;


            if (include != null)
            {
                query = include(query);
            }

            return await query.AsNoTracking()
                .ToPagedListAsync(paginationParameters.PageNumber, paginationParameters.PageSize);
        }
    }
}
