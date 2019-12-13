using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Hamgoon.API.Models
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

        public static object NewResponse<T>(bool status, string msg, IQueryable<T> data)
                 {
                     return new
                     {
                         data = data,
                         status = status,
                         massage = msg
                     };
                 }
        public static object NewResponse<T>(bool status, string msg, List<T> data)
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
