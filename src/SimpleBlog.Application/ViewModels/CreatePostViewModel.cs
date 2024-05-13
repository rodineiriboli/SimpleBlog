using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.ViewModels
{
    public class CreatePostViewModel
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo Senha precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Mensagem é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo Senha precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid UserId { get; set; }
    }
}
