using CrudSample.API.EndPointFilters.FiltersrResponse;
using CrudSample.Core.Dtos;
using CrudSample.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudSample.API.EndPointFilters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(GeneralResponse<GetOneResult<Person>>.Fail(400, errors));
            }
        }
    }
}
