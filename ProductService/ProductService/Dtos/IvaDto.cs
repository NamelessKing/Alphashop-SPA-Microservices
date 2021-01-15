using ProductService.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class IvaDto : IDto
    {
        public int IvaId { get; set; }
        public string Descrizione { get; set; }
        public short Aliquota { get; set; }
    }
}
