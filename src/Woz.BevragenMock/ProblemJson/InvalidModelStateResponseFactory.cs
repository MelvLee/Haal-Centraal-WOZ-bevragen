using Microsoft.AspNetCore.Mvc;
using Serilog;
using Woz.BevragenMock.Generated;
using Woz.BevragenMock.Http;

namespace Woz.BevragenMock.ProblemJson;

public static class InvalidModelStateResponseFactory
{
    public static IMvcBuilder ConfigureInvalidModelStateHandling(this IMvcBuilder builder)
    {
        return builder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context => CreateProblemDetails(context);
        });
    }

    private static IActionResult CreateProblemDetails(ActionContext context)
    {
        var invalidParams = (from kvp in context.ModelState
                             from error in kvp.Value.Errors
                             select new InvalidParams
                             {
                                 Name = $"{char.ToLowerInvariant(kvp.Key[0])}{kvp.Key[1..]}",
                                 Code = error.ErrorMessage.Contains("||")
                                     ? error.ErrorMessage.Split("||")[0]
                                     : null,
                                 Reason = error.ErrorMessage.Contains("||")
                                     ? error.ErrorMessage.Split("||")[1]
                                     : error.ErrorMessage
                             }).ToList();

        var titel = "Een of meerdere parameters zijn niet correct.";
        var code = "paramsValidation";
        BadRequestFoutbericht foutbericht;
        switch (invalidParams.Count)
        {
            case 1:
                foutbericht = invalidParams[0].Name switch
                {
                    "noRequiredParams" => context.HttpContext.CreateBadRequestFoutbericht(
                                            "Tenminste één parameter moet worden opgegeven.",
                                            null,
                                            invalidParams[0].Reason,
                                            null),
                    "unsupportedCombi" => context.HttpContext.CreateBadRequestFoutbericht(
                                            "De combinatie van opgegeven parameters is niet toegestaan.",
                                            "unsupportedCombi",
                                            invalidParams[0].Reason,
                                            null),
                    _ => context.HttpContext.CreateBadRequestFoutbericht(
                                            titel,
                                            code,
                                            invalidParams)
                };
                break;
            default:
                foutbericht = context.HttpContext.CreateBadRequestFoutbericht(
                        titel,
                        code,
                        invalidParams);
                break;
        }

        var requestBody = context.HttpContext.Request.ReadBodyAsync().Result;

        var diagnosticContext = context.HttpContext.RequestServices.GetRequiredService<IDiagnosticContext>();
        diagnosticContext.Set("request.body", requestBody);
        diagnosticContext.Set("request.headers", context.HttpContext.Request.Headers);
        diagnosticContext.Set("response.body", foutbericht, true);

        return new BadRequestObjectResult(foutbericht)
        {
            ContentTypes = { ContentTypes.ProblemJson }
        };
    }
}
