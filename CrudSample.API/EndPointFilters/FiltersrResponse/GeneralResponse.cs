using System.Text.Json.Serialization;

namespace CrudSample.API.EndPointFilters.FiltersrResponse
{
    public class GeneralResponse<T>
    {
        public bool msgType { get; set; }
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static GeneralResponse<T> Fail(int statusCode, List<string> errors)
        {
            return new GeneralResponse<T> { StatusCode = statusCode, Errors = errors, msgType = false };
        }
    }
}
