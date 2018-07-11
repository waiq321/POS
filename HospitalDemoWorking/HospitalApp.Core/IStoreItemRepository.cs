using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Core
{
   public interface IStoreItemRepository
    {
       void Add(StoreItems _StoreItem);

       void Edit(StoreItems _StoreItem);

       void Remove(int _StoreItemID);

       IEnumerable<StoreItems> getdata();
    }
}
