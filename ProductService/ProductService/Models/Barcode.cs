using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Barcode
    {
        [Key]
        [StringLength(13, MinimumLength =8, ErrorMessage = "Il Barcode deve avere da 8 a 13 cifre")]
        [Column("Barcode")]
        public string BarcodeId { get; set; }
        [Required]
        public string IdTipoArt { get; set; }

        [Column("CodArt")]
        public string ArticleId { get; set; }
        public virtual Article Article { get; set; }

    }
}
