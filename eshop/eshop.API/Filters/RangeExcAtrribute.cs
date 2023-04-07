using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class RangeExcAttribute : ExceptionFilterAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                var ex = (ArgumentOutOfRangeException)context.Exception;
                context.Result = new BadRequestObjectResult(new { error = $"belirtilen değerler ({ex.ActualValue}) kabul edilmiyor (Değer aralığı {Min} ile {Max} arasında olmalı)" });
            }
        }
    }
}
