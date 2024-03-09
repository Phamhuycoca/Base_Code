using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Common
{
    public class QueryItems
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string? search { get; set; } = "";
    }
}
