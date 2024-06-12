using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PresentationLayer.ActionFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.Extensions.DependencyInjection;

    public class ErrorExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider _metadataProvider;

        public ErrorExceptionFilter(IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            string message = context.Exception.Message;

            context.ExceptionHandled = true;

            var result = new ViewResult
            {
                ViewName = "CustomError" 
            };

            var viewData = new ViewDataDictionary(_metadataProvider, context.ModelState)
            {
                ["Controller"] = context.RouteData.Values["controller"].ToString(),
                ["Action"] = context.RouteData.Values["action"].ToString(),
                ["ErrorMessage"] = message
            };

            result.ViewData = viewData;

            context.Result = result;
        }
    }
}
