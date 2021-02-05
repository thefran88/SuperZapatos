using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Models
{
    [Table("Stores")]
    public class Store
    {
        #region Constructors
        public Store()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(200)]
        public string address { get; set; }
        #endregion
    }
}