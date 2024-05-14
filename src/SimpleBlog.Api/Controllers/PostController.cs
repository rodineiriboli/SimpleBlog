using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Hubs.Models;
using SimpleBlog.Application.Hubs.Service;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Api.Controllers
{
    public class PostController : MainController
    {
        private readonly INotificationService _notificationService;

        public PostController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [AllowAnonymous]
        [HttpGet("get-post/{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserViewModelResponse), 200)]
        public async Task<ActionResult> Get(Guid id, [FromServices] IPostService postService)
        {
            var postResponse = await postService.GetById(id);

            return CustomResponse(postResponse);
        }

        [AllowAnonymous]
        [HttpGet("getAll-posts")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserLoginResponseViewModel), 200)]
        public async Task<ActionResult> GetAll([FromServices] IPostService postService)
        {
            IEnumerable<PostViewModelResponse> postResponse = await postService.GetAll();
            return CustomResponse(postResponse);
        }

        [HttpPost("create-post")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CreatePostViewModel>), 200)]
        public async Task<ActionResult> CreatePostAsync(CreatePostViewModel postViewModel, [FromServices] IPostService postService)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }

                var postViewModelResponse = await postService.CreatePost(postViewModel);
                if (postViewModelResponse is not null)
                {
                    //Notificação SignalR
                    var notification = new Notification
                    {
                        IdPost = postViewModelResponse.Id,
                        Title = postViewModelResponse.Title,
                        BodyMessage = postViewModelResponse.Message
                    };
                    await _notificationService.SendNotificationAsync(notification);

                    return Ok(postViewModelResponse);
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update-post")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CreatePostViewModel>), 200)]
        public async Task<ActionResult> Update(UpdatePostViewModel updatePostViewModel, [FromServices] IPostService postService)
        {
            var postResponse = await postService.Update(updatePostViewModel);
            return CustomResponse(postResponse);
        }

        [HttpDelete("delete-post")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CreatePostViewModel>), 200)]
        public async Task<ActionResult> Delete(Guid id, [FromServices] IPostService postService)
        {
            return CustomResponse(await postService.Remove(id));
        }
    }
}
