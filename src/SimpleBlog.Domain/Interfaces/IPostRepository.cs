using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Posts> AddPost(Posts post);
        Task<IEnumerable<Posts>> GetAll();
        Task<Posts> GetById(Guid id);
        Task<Posts> UpdatePost(Posts post);
    }
}
