using Woz.BevragenMock.Generated;
using Woz.BevragenMock.Http;
using Woz.BevragenMock.Json;
using Woz.BevragenMock.Stream;

namespace Woz.BevragenMock.ProblemJson;

public static class UnhandledExceptionHandler
{
    public static Foutbericht CreateInternalServerErrorFoutbericht(this HttpContext context)
    {
        return new Foutbericht
        {
            Status = StatusCodes.Status500InternalServerError,
            Instance = new Uri(context.Request.Path, UriKind.Relative),
            Title = "Internal Server error.",
            Type = new Uri(StatusCodeIdentifiers.InternalServerErrorIdentifier)
        };
    }

    public static async Task<Foutbericht> HandleUnhandledException(this HttpContext context, System.IO.Stream orgResponseBodyStream)
    {
        var message = context.CreateInternalServerErrorFoutbericht();

        using var bodyStream = message.ToJson().ToMemoryStream(context.Response.UseGzip());

        context.Response.SetHeaderPropertiesFrom(message, bodyStream);

        await bodyStream.CopyToAsync(orgResponseBodyStream);

        return message;
    }

    public static void SetHeaderPropertiesFrom(this HttpResponse response, Foutbericht foutbericht, System.IO.Stream bodyStream)
    {
        response.StatusCode = foutbericht.Status!.Value;
        response.ContentLength = bodyStream.Length;
        response.ContentType = ContentTypes.ProblemJson;
    }
}
