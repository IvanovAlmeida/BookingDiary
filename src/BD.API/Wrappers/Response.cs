using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.Wrappers
{
    public class Response<T>
    {
        public Response() { }
        public Response(T data)
        {
            Data = data;
            Success = true;
            Errors = null;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }
    }
}
