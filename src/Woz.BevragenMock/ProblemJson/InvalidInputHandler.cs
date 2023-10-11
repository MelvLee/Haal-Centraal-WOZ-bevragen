using Woz.BevragenMock.Generated;
using Woz.BevragenMock.Http;
using Woz.BevragenMock.Json;
using Woz.BevragenMock.Stream;
using Woz.BevragenMock.Validators;

namespace Woz.BevragenMock.ProblemJson;

public static class InvalidInputHandler
{
    public static BadRequestFoutbericht CreateBadRequestFoutbericht(this HttpContext context, string titel, string code, IEnumerable<InvalidParams> invalidParams)
    {
        return context.CreateBadRequestFoutbericht(titel,
                                                   code,
                                                   $"De foutieve parameter(s) zijn: {string.Join(", ", invalidParams.Select(x => x.Name))}.",
                                                   invalidParams);
    }

    public static BadRequestFoutbericht CreateBadRequestFoutbericht(this HttpContext context, string titel, string? code, string detail, IEnumerable<InvalidParams>? invalidParams)
    {
        return new BadRequestFoutbericht
        {
            Instance = new Uri(context.Request.Path, UriKind.Relative),
            Status = StatusCodes.Status400BadRequest,
            Title = titel,
            Type = new Uri(StatusCodeIdentifiers.BadRequestIdentifier),
            Code = code,
            Detail = detail,
            InvalidParams = invalidParams != null ? new List<InvalidParams>(invalidParams) : null
        };
    }

    public static async Task<Foutbericht> HandleValidationErrors(this HttpContext context, ValidationResult validationResult, System.IO.Stream orgResponseBodyStream)
    {
        var message = context.CreateBadRequestFoutbericht(
            "Een of meerdere parameters zijn niet correct.",
            "paramsValidation",
            from error in validationResult.Errors
            select new InvalidParams { Code = error.Code, Name = error.Name, Reason = error.Reason });

        using var bodyStream = message.ToJson().ToMemoryStream(context.Response.UseGzip());

        context.Response.SetHeaderPropertiesFrom(message, bodyStream);

        await bodyStream.CopyToAsync(orgResponseBodyStream);

        return message;
    }
}
