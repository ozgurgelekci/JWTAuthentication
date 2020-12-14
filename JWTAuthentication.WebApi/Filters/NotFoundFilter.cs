using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Entities.Abstract;
using JWTAuthentication.Entities.DTOs.Error;
using JWTAuthentication.Services.Abstract.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWTAuthentication.WebApi.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class, IEntity, new()
    {
        private readonly IGenericService<TEntity> _service;

        public NotFoundFilter(IGenericService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)

        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entry = await _service.GetByIdAsync(id);

            if (entry != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.StatusCode = 404;
                errorDto.Errors.Add($"Id = '{id}' is Not Found");

                context.Result = new NotFoundObjectResult(errorDto);
            }

        }
    }
}
