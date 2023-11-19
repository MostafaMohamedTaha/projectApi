using core.entity;
using core.specification;
using Microsoft.EntityFrameworkCore;

namespace repo
{
    public static class SpecEval<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery.AsQueryable();
            if (spec.Criteria != null)
            {
                #region aggregate example
                //string[] names = { "a1", "a2", "a3", "a4" };
                //var message = "hello";
                //!message=names.Aggregate(message,(a, b) => $"{a} {b}"); //hello a1 a2 =>hello a2 a3
                #endregion
                //get product from database spec
                query = query.Where(spec.Criteria);
                //get include from database spec
            }
            query = spec.Includes.Aggregate(query, (current, includeExp) => current.Include(includeExp));
            return query;
        }
    }
}
