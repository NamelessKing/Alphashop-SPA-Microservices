using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    [Table("Iva")]
    public class Iva
    {
        [Key]
        [Column("IdIva")]
        public int IvaId { get; set; }
        public string Descrizione { get; set; }
        [Required]
        public Int16 Aliquota { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}
