using System.Text.Json;
using Newtonsoft.Json;
namespace DataGrid.Application.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static T ConvertToType<T>(this JsonElement jsonElement)
        {
            var jsonString = jsonElement.GetRawText();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }

}
