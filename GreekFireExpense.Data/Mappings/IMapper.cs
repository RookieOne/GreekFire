
namespace GreekFireExpense.Data.Mappings
{
    /// <summary>
    /// Interface for an entity mapper. Allows Entities to be mapped to Data Entities
    /// and vice versa
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <typeparam name="D"></typeparam>
    public interface IMapper<E, D>
    {
        /// <summary>
        /// Gets the entity from a data entity.
        /// </summary>
        /// <param name="dataEntity">The data entity.</param>
        /// <returns></returns>
        E GetEntity(D dataEntity);

        /// <summary>
        /// Gets the data entity from an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        D GetDataEntity(E entity);
    }
}
