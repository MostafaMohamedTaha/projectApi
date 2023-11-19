using core.entity;
using System.Linq.Expressions;

namespace core.specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        #region implement id,includes interfaces

        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        #endregion

        #region ctor id,includes
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        #endregion
    }
}
