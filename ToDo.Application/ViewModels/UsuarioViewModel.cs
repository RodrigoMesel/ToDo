using System.ComponentModel;

namespace ToDo.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Nome usuário")]
        public string Name { get; set; }
    }
}
