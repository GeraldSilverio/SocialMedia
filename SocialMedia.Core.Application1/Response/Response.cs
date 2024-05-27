using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Application1.Response
{
    /// <summary>
    /// Clase para los response genericos de la API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(bool succeeded, string? message, T? data)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
