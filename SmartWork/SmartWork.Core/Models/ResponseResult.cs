using SmartWork.Core.Enums;

namespace SmartWork.Core.Models
{
    public class ResponseResult
    {
        public string Name { get; set; }

        public static string GetResponse(ResponseType type)
        {
            switch (type)
            {
                case ResponseType.Success:
                    return "Success";
                case ResponseType.Failed:
                    return "Failed";
                default:
                    return "No response";
            }
        }
    }
}
