using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string Error { get; set; }

        public ErrorMessage(string message, string error)
        {
            Message = message;
            Error = error;
        }
    }
}
