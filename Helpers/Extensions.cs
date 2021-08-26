using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace PlayGround.WebAPI.Helpers
{
    public static class Helper
    {
        public static StringContent GetStringContent(this object obj)
            => new(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

    }
}