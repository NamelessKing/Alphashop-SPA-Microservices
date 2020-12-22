using ProductService.Dtos.Contracts;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class ArticleDto : IDto
    {
        public string ArticleId { get; set; }
        public string Descrizione { get; set; }
        public string Um { get; set; }
        public string CodStat { get; set; }
        public short? PzCart { get; set; }
        public double? PesoNetto { get; set; }
        public DateTime? DataCreazione { get; set; }
        public ICollection<BarcodeDto> Barcodes { get; set; } = new List<BarcodeDto>();
        public IvaDto Iva { get; set; }
        public IngredientDto Ingredient { get; set; }
        public AssortmentFamilyDto AssortmentFamily { get; set; }
    }
}
