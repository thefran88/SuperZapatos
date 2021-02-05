using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Models
{

    [Table("Articles")]
    public class Article
    {
        #region Constructors 
        public Article()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public float total_in_shelf { get; set; }

        public float total_in_vault { get; set; }

        public virtual Store store { get; set; }

        [NotMapped]
        public string store_name
        {
            get
            {
                return store.name;
            }
        }
        #endregion
    }
}