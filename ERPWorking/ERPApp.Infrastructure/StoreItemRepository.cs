using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPApp.Core;
using System.Data;
using System.Data.Entity;

namespace ERPApp.Infrastructure
{
  public  class StoreItemRepository : IStoreItemRepository
    {
        StoreContext context = new StoreContext();
        public void Add(StoreItems _StoreItem)
        {
            context.StoreItem.Add(_StoreItem);
            context.SaveChanges();
        }

        public void Edit(StoreItems _StoreItem)
        {
            context.Entry(_StoreItem).State = EntityState.Modified;
        }

        public void Remove(int _StoreItemID)
        {
            StoreItems storeItem=context.StoreItem.Find(_StoreItemID);
            context.StoreItem.Remove(storeItem);
            context.SaveChanges();
        }

        public IEnumerable<StoreItems> getdata()
        {
         return   context.StoreItem.ToList();
        }
    }
}
