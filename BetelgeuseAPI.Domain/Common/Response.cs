using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Domain.Common
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Response()
        {
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T>
            {
                Succeeded = false,
                Message = message
            };
        }
        public static Response<T> Success(T data, string message = null)
        {
            return new Response<T>
            {
                Succeeded = true,
                Message = message,
                Data = data
            };
        }
        public static Response<T> Success(string message)
        {
            return new Response<T>
            {
                Succeeded = true,
                Message = message,
            };
        }
    }
}
