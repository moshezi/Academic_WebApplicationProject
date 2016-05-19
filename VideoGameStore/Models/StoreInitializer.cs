/*
  Moshe itzhaki 021558200
  David epshtein 304259203
  Yael houry 305557654
  Idan levy 032587933
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VideoGamesStoreContext>
    {
        protected override void Seed(VideoGamesStoreContext context)
        {
            var products = new List<Products>
            {
            new Products{ProductID=1,productName="PlayStation4",price=2499,type="Console",isExist="yes"},
            new Products{ProductID=2,productName="PlayStation3",price=1850,type="Console",isExist="yes"},
            new Products{ProductID=3,productName="XBOXONE",price=2599,type="Console",isExist="yes"},
            new Products{ProductID=4,productName="XBOX360",price=1845,type="Console",isExist="yes"},
            new Products{ProductID=5,productName="WII U",price=2399,type="Console",isExist="yes"},
            new Products{ProductID=6,productName="WII",price=1299,type="Console",isExist="yes"},
            new Products{ProductID=7,productName="FIFA2015",price=59,type="Games",isExist="yes"},
            new Products{ProductID=8,productName="NBA2K2015",price=59,type="Games",isExist="yes"},
            new Products{ProductID=9,productName="GTA5",price=59,type="Games",isExist="yes"},
            new Products{ProductID=10,productName="Call of Duty Black Ops 3",price=59,type="Games",isExist="yes"},
            new Products{ProductID=11,productName="Need for Speed 2015",price=59,type="Games",isExist="yes"},
            new Products{ProductID=12,productName="Street Fighter V",price=59,type="Games",isExist="yes"},
            new Products{ProductID=13,productName="PS4 Controller",price=55,type="Accerssories",isExist="yes"},
            new Products{ProductID=14,productName="XBOXONE Controller",price=50,type="Accerssories",isExist="yes"},
            new Products{ProductID=15,productName="WII U Controller",price=49,type="Accerssories",isExist="yes"},
            new Products{ProductID=15,productName="PS4 Headset",price=39,type="Accerssories",isExist="yes"},
            new Products{ProductID=15,productName="XBOXONE Headset",price=39,type="Accerssories",isExist="yes"},
             new Products{ProductID=15,productName="WII U Headset",price=39,type="Accerssories",isExist="yes"},
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            var orders = new List<Orders>
            {
            new Orders{OrderID=1,ProductID=1,customerName="Moshe",customerPhone="050-1278347",city="Givatyim",adress="Beeri 2, Givatyim",orderPrice=4200},
            new Orders{OrderID=2,ProductID=1,customerName="David",customerPhone="050-3456221",city="Petah-tikva",adress="Yarkon 12, Petah-tikva",orderPrice=3299},
            new Orders{OrderID=3,ProductID=2,customerName="Yael",customerPhone="054-3381212",city="Tel aviv",adress="Dizingof 20, Tel Aviv ",orderPrice=1700},
            new Orders{OrderID=4,ProductID=2,customerName="Idan",customerPhone="052-8383574",city="Rishon lezion",adress="Yizman 58, Rishon lezion",orderPrice=5320},
            new Orders{OrderID=4,ProductID=2,customerName="Eli",customerPhone="052-9845354",city="Hifa",adress="Yizhak-rabin 76, Hifa",orderPrice=3200},
            new Orders{OrderID=4,ProductID=2,customerName="Erez",customerPhone="052-332154",city="Tel aviv",adress="Allenby 55, Tel Aviv",orderPrice=1800},           
            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
          


            var suppliers = new List<Suppliers>
            {
            new Suppliers{SupplierID=1,ProductID=1,Name="Dani",phoneNumber="058-1122112",city="tel-aviv",adress="yizman 15"},
            new Suppliers{SupplierID=2,ProductID=2,Name="Asaf",phoneNumber="052-1232112",city="netanya",adress="hevron 15"},
            new Suppliers{SupplierID=3,ProductID=3,Name="Yaron",phoneNumber="053-892312",city="ramat-gan",adress="beeri 18/8"},
            new Suppliers{SupplierID=4,ProductID=4,Name="Michal",phoneNumber="054-9873112",city="jerusalem",adress="golda 9/1"},
            new Suppliers{SupplierID=5,ProductID=4,Name="Avi",phoneNumber="054-3465842",city="hifa",adress="rabin 12/1"},
            };

            suppliers.ForEach(s => context.Suppliers.Add(s));
            context.SaveChanges();

            
        }
    }
}