using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PagingApp.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
    }

    public class MobileDbInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone { Model = "Iphone X", Producer = "Apple" });
            db.Phones.Add(new Phone { Model = "Redmi 3", Producer = "Xiaomi" });
            db.Phones.Add(new Phone { Model = "Redmi 5 plus", Producer = "Xiaomi" });
            db.Phones.Add(new Phone { Model = "Galaxy 5 plus", Producer = "Samsung" });
            db.Phones.Add(new Phone { Model = "Galaxy s9", Producer = "Samsung" });
            db.SaveChanges();
        }
    }
}