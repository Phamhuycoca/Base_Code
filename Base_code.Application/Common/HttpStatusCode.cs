using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Common
{
    public static class HttpStatusCode
    {
        public static int OK=>200;
        public static int BAD_REQUEST => 400;
        public static int UNAUTHORIZED => 401;
        public static int FORBIDDEN => 400;
        public static int NOT_FOUND => 400;
        public static int CONFLICT => 400;
        public static int UNPROCESSABLE_ENTITY => 400;
        public static int ITEM_NOT_FOUND => 400;
        public static int ITEM_ALREADY_EXIST => 400;
        public static int ITEM_INVALID => 400;
        public static int INTERNAL_SERVER_ERROR => 400;
        public static int SERVICE_UNAVAILABLE => 400;
    }
}
