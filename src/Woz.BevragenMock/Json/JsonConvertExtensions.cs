using Newtonsoft.Json;

namespace Woz.BevragenMock.Json;

public static class JsonConvertExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static string ToJsonWithoutNullAndDefaultValues(this object? obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });
    }
}
