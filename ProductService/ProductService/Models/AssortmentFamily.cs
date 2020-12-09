using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    [Table("FamAssort")]
    public class AssortmentFamily
    {
        [Key]
        [Column("Id")]
        public int AssortmentFamilyId { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Article> Articoli { get; set; }
    }
}
