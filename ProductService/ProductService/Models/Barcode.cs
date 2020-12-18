using ProductService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    [Table("Barcode")]
    public class Barcode : IEntity
    {
        [Key]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Il Barcode deve avere da 8 a 13 cifre")]
        [Column("Barcode")]
        public string BarcodeId { get; set; }
        [Required]
        public string IdTipoArt { get; set; }

        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]
        [ForeignKey("ArticleId")]
        [Column("CodArt")]
        public string? ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
