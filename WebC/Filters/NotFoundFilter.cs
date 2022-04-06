using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebC.Filters
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

            var entity = await _service.AnyAsync(x => x.Id == (int)id);
            if (entity)
            {
                await next.Invoke();
                return;
            }
            var errvm = new ErrorViewModel();
            errvm.Errors.Add($"{typeof(T).Name} not found..");

            context.Result = new RedirectToActionResult("Error","Home",errvm);
        }
    }
}
