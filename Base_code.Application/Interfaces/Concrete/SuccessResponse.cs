using Base_code.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Interfaces.Concrete
{
    public class SuccessResponse : ISuccessResponse
    {
        public bool Success { get; } = true;
        public string Message { get; }
        public int StatusCode { get; }


        public SuccessResponse()
        {

        }

        public SuccessResponse(int statuscode, string message)
        {
            StatusCode = statuscode;
            Message = message;
        }
    }
}
