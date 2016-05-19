/*
  Moshe itzhaki 021558200
  David epshtein 304259203
  Yael houry 305557654
  Idan levy 032587933
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace VideoGameStore.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string customerPhone { get; set; }
        [Display(Name = "City-Branch")]
        public string city { get; set; }
        [Display(Name = "Full-Address")]
        public string adress { get; set; }
        [Display(Name = "Order Price")]
        public double? orderPrice { get; set; }
        [ScriptIgnore]
        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }
    }
}