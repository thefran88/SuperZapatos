using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Models
{
    public class Article
    {
        #region Constructors 
        public Article()
        {

        }
        #endregion

        #region Properties
        public int id { get; set; }

        [Display(Name="Nombre")]
        public string name { get; set; }

        [Display(Name ="Descripción")]
        public string description { get; set; }

        [Display(Name = "Precio")]
        public decimal price { get; set; }

        [Display(Name = "Total en estantería")]
        public float total_in_shelf { get; set; }

        [Display(Name = "Total en bóveda")]
        public float total_in_vault { get; set; }

        public virtual Store Store { get; set; }

        [NotMapped]
        public string store_name { get; set; }
        #endregion
    }
}