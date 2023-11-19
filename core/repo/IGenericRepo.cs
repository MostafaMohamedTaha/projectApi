using core.entity;
using core.specification;

namespace core.repo
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        #region crud Task

        #region get all
        //Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncWithSpecs(ISpecification<T> spec);
        #endregion

        #region get by Id

        //Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsyncWithSpecs(ISpecification<T> spec);
        #endregion

        #region create
        Task<T> CreateAsync(T entity);
        #endregion

        #region update

        Task<T> UpdateAsync(T entity);
        #endregion

        #region delete
        Task<T> DeleteAsync(int id);
        #endregion
        #endregion


    }
}
