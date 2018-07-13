using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApp.Core;
using HospitalApp.Core.HospitalAdminViewModels;

using System.Data.Entity;

namespace HospitalApp.Infrastructure
{
   public class ItemCatageoryRepository:IItemCatageory
    {
       StoreContext context = new StoreContext();
        public void Add(ItemCatageory _itemCatageory)
        {
            context.ItemCatageory.Add(_itemCatageory);
            context.SaveChanges();
        }

        public void Edit(ItemCatageory _itemCatageory)
        {
            context.Entry(_itemCatageory).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int _id)
        {
            ItemCatageory itemCatageory=context.ItemCatageory.Find(_id);
            context.ItemCatageory.Remove(itemCatageory);
            context.SaveChanges();
        }
      
        public IEnumerable<ItemType> GetAllItemTypes()
        {
           return context.ItemType.ToList();
        }

        public string GetItemType(int ItemTypeID)
        {
            return (context.ItemType.FirstOrDefault(s => s.ID.Equals(ItemTypeID))).TypeName;
        }

        public IEnumerable<ItemCatageoryViewModel> getItemCatageories()
        {
           var catageoryList =context.ItemCatageory.AsNoTracking().Include(s => s.ItemType).ToList();

           if (catageoryList != null)
           {
               List<ItemCatageoryViewModel> viewModel = new List<ItemCatageoryViewModel>();
               foreach (var item in catageoryList)
               {
                   var viewmodelDisplay=new ItemCatageoryViewModel(){
                    Name=item.CatageoryName,
                     ItemTypeID=item.ItemTypeID,
                      ItemCatageoryID=item.ID,
                        ItemTypeName=GetItemType(item.ItemTypeID.HasValue?item.ItemTypeID.Value:0)

                   };
                   viewModel.Add(viewmodelDisplay);

               }
               return viewModel;
           }
           return null;
        }
 
        
    }
}
