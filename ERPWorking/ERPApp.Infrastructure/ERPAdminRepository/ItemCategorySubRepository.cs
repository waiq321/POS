using System;
using System.Collections.Generic;
using System.Linq;
using ERPApp.Core;
using System.Data.Entity;
using ERPApp.Infrastructure.ViewModels;

namespace ERPApp.Infrastructure.ERPAdminRepository
{
    public class ItemCategorySubRepository
    {
        public void Add(ItemCategorySub ICS)
        {

            using (ERPContext context = new ERPContext())
            {
                context.ItemCategorySub.Add(ICS);
                context.SaveChanges();
            }

        }

        public void Update(ItemCategorySub ICS)
        {
            using (ERPContext context = new ERPContext())
            {
                context.Entry(ICS).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void Remove(int id)
        {
            using (ERPContext context = new ERPContext())
            {
                ItemCategorySub objICS = context.ItemCategorySub.Find(id);
                context.ItemCategorySub.Remove(objICS);
                context.SaveChanges();
            }
        }
        public List<ItemCategorySubViewModel> GetCategoriesList(int CatId=0)
        {
            using (ERPContext context = new ERPContext())
            {
                IQueryable<ItemCategorySubViewModel> ItemCategorySubViewModel = (from cs in context.ItemCategorySub
                                                                                 join cm in context.ItemCategoryMain on cs.CategoryId equals cm.CategoryId
                                                                                 where cm.Active & cs.Active & cm.BranchId == 4
                                                                                 select new ItemCategorySubViewModel
                                                                                 {
                                                                                     SubCategoryId = cs.SubCategoryId,
                                                                                     SubCategoryName = cs.SubCategoryName,
                                                                                     CategoryId = cs.CategoryId,
                                                                                     CategoryName = cm.CategoryName,
                                                                                     Abb = cs.Abb
                                                                                 }
                                                      );
                if (CatId!=0)
                {
                    
                        ItemCategorySubViewModel = ItemCategorySubViewModel.Where(b => b.SubCategoryId == CatId);
                }
                
                return ItemCategorySubViewModel.ToList();
            }
        }

        public IEnumerable<ItemCategorySubViewModel> GetCategories()
        {
            
                var categoryList = GetCategoriesList();
                if (categoryList != null)
                {
                   
                        List<ItemCategorySubViewModel> _ICSVMList = new List<ItemCategorySubViewModel>();

                        foreach (var item in categoryList)
                        {
                            ItemCategorySubViewModel model = new ItemCategorySubViewModel();
                            model.SubCategoryId = item.SubCategoryId;
                            model.SubCategoryName = item.SubCategoryName;
                            model.CategoryName = item.CategoryName;
                            model.CategoryId = item.CategoryId;
                            model.Abb = item.Abb;


                            _ICSVMList.Add(model);
                        }
                        return _ICSVMList;
                    
                }
           
            return null;
        }


        public ItemCategorySubViewModel GetCategoryByID(int id)
        {
            ItemCategorySubViewModel model = new ItemCategorySubViewModel();
            IEnumerable<ItemCategorySubViewModel> categoryList = GetCategoriesList(id);
            ItemCategorySubViewModel category = categoryList.FirstOrDefault();

            CommonRepository objCommonRepository = new CommonRepository();            
            if (categoryList.Any())
            {
                model.SubCategoryId = category.SubCategoryId;
                model.SubCategoryName = category.SubCategoryName;
                model.Abb = category.Abb;
                model.Categories = objCommonRepository.GetMainCategories(false, category.CategoryId);
                model.CategoryName = category.CategoryName;
                return model;
            }
            return null;
        }
    }

}
