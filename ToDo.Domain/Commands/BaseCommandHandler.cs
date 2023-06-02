using FluentValidation.Results;
using ToDo.Domain.Core.Interfaces;

namespace ToDo.Domain.Commands
{
    public class BaseCommandHandler
    {
        protected ValidationResult _validationResult;
        protected readonly IUnitOfWork _uow;

        public BaseCommandHandler(IUnitOfWork uow)
        {
            _validationResult = new ValidationResult();
            _uow = uow;
        }

        protected void AddError(string message)
        {
            _validationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task CommitAsync() 
        {
            if (_validationResult.Errors.Count == 0)
            {

                try
                {
                    await _uow.CommitAsync();
                }
                catch (Exception ex)
                {
                    AddError(ex.Message);

                }
            }
            
        }
    }
}
