using AutoMapper;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Interfaces;

namespace SimpleBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IMapper mapper, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreatePostResponse> CreatePost(CreatePostViewModel postViewModel)
        {
            try
            {
                var user = _userRepository.GetUserById(postViewModel.UserId);
                if (user is null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                var post = _mapper.Map<Posts>(postViewModel);
                post.Id = Guid.NewGuid();
                post.UserId = postViewModel.UserId;
                post.Active = true;

                var postCreated = await _postRepository.AddPost(post);

                var postResponde = _mapper.Map<CreatePostResponse>(postCreated);

                return postResponde;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PostViewModelResponse>> GetAll()
        {
            var posts = await _postRepository.GetAll();

            var postsResponse = _mapper.Map<IEnumerable<PostViewModelResponse>>(posts);

            return postsResponse;
        }

        public async Task<PostViewModelResponse> GetById(Guid id)
        {
            var postResponse = _mapper.Map<PostViewModelResponse>(await _postRepository.GetById(id));

            return postResponse;
        }

        public async Task<PostViewModelResponse> Remove(Guid id)
        {
            var post = await _postRepository.GetById(id);

            if (post is not null)
            {
                post.Active = false;
                await _postRepository.UpdatePost(post);
            }


            var postResponse = _mapper.Map<PostViewModelResponse>(post);

            return postResponse;
        }

        public async Task<PostViewModelResponse> Update(UpdatePostViewModel updatePostViewModel)
        {
            var post = await _postRepository.GetById(updatePostViewModel.Id);


            if (post is not null)
            {
                if (post.UserId == updatePostViewModel.UserId)
                {
                    post.Title = updatePostViewModel.Title;
                    post.Message = updatePostViewModel.Message;

                    await _postRepository.UpdatePost(post);
                }
            }

            var postResponse = _mapper.Map<PostViewModelResponse>(post);

            return postResponse;
        }
    }
}