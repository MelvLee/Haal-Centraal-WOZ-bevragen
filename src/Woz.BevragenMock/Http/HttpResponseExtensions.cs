namespace Woz.BevragenMock.Http;

public static class HttpResponseExtensions
{
    public static bool UseGzip(this HttpResponse response) => response.Headers.ContentEncoding.Contains("gzip");
}
