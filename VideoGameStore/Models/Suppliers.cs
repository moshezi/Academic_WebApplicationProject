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

namespace VideoGameStore.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Address")]
        public string adress { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }
    }
}