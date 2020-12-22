using ProductService.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class IngredientDto : IDto
    {
        public string Info { get; set; }
        public string ArticleId { get; set; }
    }
}
