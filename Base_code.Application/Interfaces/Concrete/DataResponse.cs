using Base_code.Application.Interfaces.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Base_code.Application.Interfaces.Concrete
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public bool Success { get; } = true;
        public T Data { get; }
        public int StatusCode { get; }
        public string Message { get; set; }

        public int totalItems { get; }

        [JsonConstructor]
        public DataResponse(T data,int totalItems, int statuscode)
        {
            this.totalItems = totalItems;
            Data = data;
            StatusCode = statuscode;
        }

        public DataResponse(T data, int statuscode, string message)
        {
            Data = data;
            StatusCode = statuscode;
            Message = message;
        }
    }
}
