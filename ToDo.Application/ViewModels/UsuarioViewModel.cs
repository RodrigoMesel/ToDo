using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid UserId { get; set; }

        [DisplayName("Nome usuário")]
        public string Name { get; set; }
    }
}
