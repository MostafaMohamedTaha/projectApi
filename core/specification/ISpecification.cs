using core.entity;
using System.Linq.Expressions;

namespace core.specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        #region spec by id ,includes

        //p=>p.id==id
        public Expression<Func<T, bool>> Criteria { get; set; }
        // includes query
        public List<Expression<Func<T, object>>> Includes { get; set; }
        #endregion
    }
}
