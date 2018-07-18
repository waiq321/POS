using System;
using System.Collections.Generic;
using System.Linq;
using ERPApp.Core;
using System.Data.Entity;
using ERPApp.Infrastructure.ViewModels;

namespace ERPApp.Infrastructure.ERPAdminRepository
{
    public class ItemCategoryMainRepository
    {
        public void Add(ItemCategoryMain ICM)
        {

            using (ERPContext context = new ERPContext())
            {
                context.ItemCategoryMain.Add(ICM);
                context.SaveChanges();
            }

        }

        public void Update(ItemCategoryMain ICM)
        {
            using (ERPContext context = new ERPContext())
            {
                context.Entry(ICM).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void Remove(int id)
        {
            using (ERPContext context = new ERPContext())
            {
                ItemCategoryMain objItemCategoryMain = context.ItemCategoryMain.Find(id);
                context.ItemCategoryMain.Remove(objItemCategoryMain);
                context.SaveChanges();
            }
        }


        public IEnumerable<ItemCategoryMainViewModel> GetCategories()
        {
            using (ERPContext context = new ERPContext())
            {
                var categoryList = context.ItemCategoryMain.ToList();
                if (categoryList != null)
                {
                    List<ItemCategoryMainViewModel> _ICMainVMList = new List<ItemCategoryMainViewModel>();

                    foreach (var item in categoryList)
                    {
                        ItemCategoryMainViewModel model = new ItemCategoryMainViewModel();
                        model.CategoryId = item.CategoryId;
                        model.CategoryName = item.CategoryName;
                        model.Abb = item.Abb;


                        _ICMainVMList.Add(model);
                    }
                    return _ICMainVMList;
                }
            }
            return null;
        }


        public ItemCategoryMainViewModel GetCategoryByID(int id)
        {
            ItemCategoryMainViewModel model = new ItemCategoryMainViewModel();            
            using (ERPContext context = new ERPContext())
            {
                var company = context.ItemCategoryMain.Find(id);
                if (company != null)
                {
                    model.CategoryId = company.CategoryId;
                    model.CategoryName = company.CategoryName;
                    model.Abb = company.Abb;
                  
                    return model;
                }
            }
            return null;
        }
    }

}
