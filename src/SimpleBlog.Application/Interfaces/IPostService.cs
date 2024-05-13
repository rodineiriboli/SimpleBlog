using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces
{
    public interface IPostService
    {
        Task<CreatePostResponse> CreatePost(CreatePostViewModel postViewModel);
        Task<IEnumerable<PostViewModelResponse>> GetAll();
        Task<PostViewModelResponse> GetById(Guid id);
        Task<PostViewModelResponse> Remove(Guid id);
        Task<PostViewModelResponse> Update(UpdatePostViewModel updatePostViewModel);
    }
}
