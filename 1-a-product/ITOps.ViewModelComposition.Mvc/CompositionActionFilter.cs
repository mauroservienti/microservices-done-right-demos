using ITOps.ViewModelComposition.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITOps.ViewModelComposition.Mvc
{
    class CompositionActionFilter : IAsyncResultFilter
    {
        IEnumerable<IHandleResult> resultHandlers;

        public CompositionActionFilter( IEnumerable<IHandleResult> resultHandlers )
        {
            this.resultHandlers = resultHandlers;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            (var viewModel, var statusCode) = await CompositionHandler.HandleRequest(context.HttpContext);

            var routeData = context.HttpContext.GetRouteData();
            var request = context.HttpContext.Request;

            //matching handlers could be cached by URL
            //per route only 1 result handler is allowed, the owning one
            var handler = resultHandlers
                .Where(a => a.Matches(routeData, request.Method, request))
                .SingleOrDefault();

            if (handler != null)
            {
                await handler.Handle(context, viewModel, statusCode);
            }
            else
            {
                defaultHandler();
            }

            await next();

            void defaultHandler()
            {
                if (context.Result is ViewResult viewResult && viewResult.ViewData.Model == null)
                {
                    //MVC
                    if (statusCode == StatusCodes.Status200OK)
                    {
                        viewResult.ViewData.Model = viewModel;
                    }
                }
                else if (context.Result is ObjectResult objectResult && objectResult.Value == null)
                {
                    //WebAPI
                    if (statusCode == StatusCodes.Status200OK)
                    {
                        objectResult.Value = viewModel;
                    }
                }
            }
        }
    }
}
