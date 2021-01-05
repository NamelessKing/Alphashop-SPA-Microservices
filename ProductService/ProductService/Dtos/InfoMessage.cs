using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class InfoMessage
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public InfoMessage(DateTime date, string message)
        {
            Date = date;
            Message = message;
        }
    }
}
