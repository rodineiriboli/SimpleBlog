using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Api.Controllers
{
    public class PostController : MainController
    {
        [HttpPost]
        [Route("create-post")]
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
                    return Ok(postViewModelResponse);
                }

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-post")]
        public async Task<ActionResult> Delete(Guid id, [FromServices] IPostService postService)
        {
            return CustomResponse(await postService.Remove(id));
        }

        [HttpPut("update-post")]
        public async Task<ActionResult> Update(UpdatePostViewModel updatePostViewModel, [FromServices] IPostService postService)
        {
            var postResponse = await postService.Update(updatePostViewModel);
            return CustomResponse(postResponse);
        }

        [HttpGet("get-post/{id:guid}")]
        public async Task<ActionResult> Get(Guid id, [FromServices] IPostService postService)
        {
            var postResponse = await postService.GetById(id);
            return CustomResponse(postResponse);
        }

        [HttpGet("get-post")]
        public async Task<ActionResult> GetAll([FromServices] IPostService postService)
        {
            IEnumerable<PostViewModelResponse> postResponse = await postService.GetAll();
            return CustomResponse(postResponse);
        }
    }
}
