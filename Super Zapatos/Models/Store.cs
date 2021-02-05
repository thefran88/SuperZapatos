using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Models
{
    public class Store
    {
        #region Constructors
        public Store()
        {

        }
        #endregion

        #region Properties
        public int id { get; set; }

        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Display(Name = "Dirección")]
        public string address { get; set; }
        #endregion
    }
}