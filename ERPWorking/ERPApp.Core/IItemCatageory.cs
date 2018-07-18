using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPApp.Core.ERPAdminViewModels;

namespace ERPApp.Core
{
  public  interface IItemCatageory
    {
      void Add(ItemCatageory _itemCatageory);
      void Edit(ItemCatageory _itemCatageory);
      void Remove(int _id);

      IEnumerable<ItemType> GetAllItemTypes();
      IEnumerable<ItemCatageoryViewModel> getItemCatageories();

    }
}
