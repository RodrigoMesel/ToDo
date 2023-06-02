using FluentValidation;
using ToDo.Domain.Commands.UsuarioCommands;

namespace ToDo.Domain.Commands.UsuarioCommands.Validations
{
    public class UserCommandValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {

        protected void ValidateId()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Informe o ID do usuário");
        }

        protected void ValidateName()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Informe o nome do usuário")
                .Length(2, 100).WithMessage("O nome do usuário precisa ter entre 2 e 100 caracteres.");
        }
    }
}
