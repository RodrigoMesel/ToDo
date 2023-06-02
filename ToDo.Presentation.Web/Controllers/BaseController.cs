using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Presentation.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool ResponseHasErrors(ValidationResult result)
        {
            if (result == null || result.IsValid) return false;

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }

            return true;
        }
    }
}
