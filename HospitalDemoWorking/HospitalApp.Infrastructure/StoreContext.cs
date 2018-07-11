using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApp.Core;

namespace HospitalApp.Infrastructure
{
  public  class StoreContext:DbContext
    {
        public StoreContext()
            : base("name=StoreConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            StoreInitilizeDB db=new StoreInitilizeDB();
            System.Data.Entity.Database.SetInitializer(db);
        }

        public DbSet<StoreItems> StoreItem { get; set; }
        public DbSet<ItemCatageory> ItemCatageory { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<ItemManufacturer> ItemManufacturer { get; set; }
    }
}
