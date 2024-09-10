using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
