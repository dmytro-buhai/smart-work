using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartWork.BLL
{
    public class StatisticHandler
    {
        public static List<T> ParseDate<T>(string data)
        {
            var parsedData = JsonConvert.DeserializeObject<List<T>>(data);

            if (data == null)
            {
                parsedData = new List<T>();
            }

            return parsedData;
        }
    }
}
