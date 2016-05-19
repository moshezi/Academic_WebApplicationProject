/*
  Moshe itzhaki 021558200
  David epshtein 304259203
  Yael houry 305557654
  Idan levy 032587933
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class VideoGamesStoreContext : DbContext
    {
    
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}