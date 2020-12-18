using ProductService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    [Table("Ingredienti")]
    public class Ingredient : IEntity
    {

        public string Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("CodArt")]
        [ForeignKey("Article")]
        public string ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
