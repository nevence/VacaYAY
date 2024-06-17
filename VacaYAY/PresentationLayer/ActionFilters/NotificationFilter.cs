using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Exceptions;

namespace PresentationLayer.ActionFilters
{
    public class NotificationFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                if (context.HttpContext.Request.Method == "POST")
                {
                    controller.TempData["SuccessMessage"] = ErrorMessages.Success;
                }
            }
        }
    }

}