using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetEntity(int id);
        Task<T> FindAsync(int? id);
        DbSet<T> GetAll();
        bool Contains(T entity);
        void Add(T entity, bool saved=false);
        void Update(T entity, bool saved = false);
        void Delete(T entity, bool saved = false);
        void Delete(int id, bool saved = false);

    }
}
