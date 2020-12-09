using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Ingredient
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
