using core.entity;
using core.repo;
using core.specification;
using Microsoft.EntityFrameworkCore;

namespace repo.data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly Context context;
        #region ctor

        public GenericRepo(Context context)
        {
            this.context = context;
        }
        #endregion

        #region interface crud

        #region get all

        #region get all old

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    if (typeof(T) == typeof(Product))

        //        return (IEnumerable<T>)context.Products.Include(x => x.ProductBrand).Include(x => x.ProductType);
        //    else
        //        return await context.Set<T>().ToListAsync();
        //}
        #endregion
        public async Task<IEnumerable<T>> GetAllAsyncWithSpecs(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        #endregion

        #region by Id
        #region get by id old

        public async Task<T> GetByIdAsync(int id)
        => await context.Set<T>().FindAsync(id);

        #endregion
        public async Task<T> GetByIdAsyncWithSpecs(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        #endregion

        #region update
        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region add
        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region delete

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region specification
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecEval<T>.GetQuery(context.Set<T>(), spec);
        }
        #endregion
    }
}
