using ProductService.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class AssortmentFamilyDto : IDto
    {
        public int AssortmentFamilyId { get; set; }
        public string Descrizione { get; set; }
    }
}
