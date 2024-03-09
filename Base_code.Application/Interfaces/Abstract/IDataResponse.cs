using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Interfaces.Abstract
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
        string Message { get; }
    }
}
