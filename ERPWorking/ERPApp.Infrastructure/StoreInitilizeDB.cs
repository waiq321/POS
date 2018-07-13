using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace HospitalApp.Infrastructure
{
    class StoreInitilizeDB:DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {

            //item Type
            Core.ItemType itemType = new Core.ItemType();
            itemType.TypeName = "Pharmacy";
            
            context.ItemType.Add(itemType);
            context.ItemType.Add(new Core.ItemType { TypeName = "General Item" });

            //item manufacturer
            Core.ItemManufacturer ItemManufacturer = new Core.ItemManufacturer();
            ItemManufacturer.Name = "Hilton Pharma";
            ItemManufacturer.ItemType = itemType;
            context.ItemManufacturer.Add(ItemManufacturer);


            base.Seed(context);
        }
    }
}
