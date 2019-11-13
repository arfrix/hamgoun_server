using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace hamgooonWebServerV1.Models
{
    public class Response
    {
        public static object NewResponse(bool status, string msg)
        {
            return new
            {
                status = status,
                massage = msg
            };
        }

        public static object NewResponse(bool status, string msg, IQueryable data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }
        public static object NewResponse(bool status, string msg, long data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }
        public static object NewResponse(bool status, string msg, CreatedAtActionResult data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }
    }
}
