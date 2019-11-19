using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMSI_API.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AMSI_RESULT
    {
        AMSI_RESULT_CLEAN = 0,
        AMSI_RESULT_NOT_DETECTED = 1,
        AMSI_RESULT_DETECTED = 32768
    }
}