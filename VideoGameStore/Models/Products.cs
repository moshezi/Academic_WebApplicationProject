/*
  Moshe itzhaki 021558200
  David epshtein 304259203
  Yael houry 305557654
  Idan levy 032587933
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string productName { get; set; }
        [Display(Name = "Price")]
        public double price { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Is Exist?")]
        public string isExist { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}