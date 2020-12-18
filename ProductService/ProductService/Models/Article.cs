using ProductService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    [Table("Articoli")]
    public class Article : IEntity
    {
        [Key]
        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]
        [Column("CodArt")]
        public string ArticleId { get; set; }

        [MinLength(5, ErrorMessage = "La Descrizione deve avere almeno 5 caratteri")]
        [MaxLength(80, ErrorMessage = "La Descrizione non può essere più lunga di 80 caratteri")]
        public string Descrizione { get; set; }
        public string Um { get; set; }
        public string CodStat { get; set; }

        [Range(0, 100, ErrorMessage = "I pezzi per cartone devono essere compresi fra 0 e 100")]
        public Int16? PzCart { get; set; }

        [Range(0.01, 100, ErrorMessage = "Il peso deve essere compre fra 0.01 e 100")]
        public double? PesoNetto { get; set; }
        
        
        //public string IdStatoArt { get; set; }
        public DateTime? DataCreazione { get; set; }

        public ICollection<Barcode> Barcodes { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Iva")]
        [Column("IdIva")]
        public int? IvaId { get; set; }
        public virtual Iva Iva { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("AssortmentFamily")]
        [Column("IDFAMASS")]
        public int? AssortmentFamilyId { get; set; }
        public AssortmentFamily AssortmentFamily { get; set; }


    }
}
