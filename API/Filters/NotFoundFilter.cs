using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{


    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           var id = context.ActionArguments.Values.FirstOrDefault();
            if (id is null)
            {
                await next.Invoke();
            }

            var entity = await _service.AnyAsync(x => x.Id == (int?)id);
            if (entity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CResponseDto<bool>.Fail(404, $"{typeof(T).Name} not found"));

        }
    }
}
