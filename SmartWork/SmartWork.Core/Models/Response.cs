using SmartWork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartWork.Core.Models
{
    public class Response
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
