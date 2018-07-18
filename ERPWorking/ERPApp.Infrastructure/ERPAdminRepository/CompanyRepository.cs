using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPApp.Core;
using System.Data.Entity;
using System.Web.Mvc;
using ERPApp.Infrastructure.ViewModels;

namespace ERPApp.Infrastructure.ERPAdminRepository
{
    public class CompanyRepository
    {
        public void Add(Company _company)
        {

            using (ERPContext context = new ERPContext())
            {
                context.Company.Add(_company);
                context.SaveChanges();
            }

        }


        public void Update(Company company)
        {
            using (ERPContext context = new ERPContext())
            {
                context.Entry(company).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void Remove(int id)
        {
            using (ERPContext context = new ERPContext())
            {
                Company _company = context.Company.Find(id);
                context.Company.Remove(_company);
                context.SaveChanges();
            }
        }


        public IEnumerable<SelectListItem> getCities(int? id)
        {
            using (ERPContext context = new ERPContext())
            {
                List<SelectListItem> _items = context.City.Select(x => new SelectListItem { Text = x.CityName, Value = x.CityId.ToString() }).ToList();

                var insertCaption = new SelectListItem() { Value = null, Text = "---Select City---" };

                _items.Insert(0, insertCaption);
                return new SelectList(_items, "Value", "Text", id);
            }
        }

        public IEnumerable<CompanyViewModel> getCompanies()
        {
            using (ERPContext context = new ERPContext())
            {
                var companiesList = context.Company.AsNoTracking().Include(x => x.Cities).ToList();
                if (companiesList != null)
                {
                    List<CompanyViewModel> _companiesViewModelList = new List<CompanyViewModel>();

                    foreach (var item in companiesList)
                    {
                        CompanyViewModel model = new CompanyViewModel();
                        model.CompanyID = item.CompanyId;
                        model.CompanyName = item.CompanyName;
                        model.CityID = item.CityId;
                        model.CityName = item.Cities.CityName;
                        model.Address = item.Address;
                        model.PhoneNo = item.Phone;
                        model.WebsiteUrl = item.WebsiteURL;

                        _companiesViewModelList.Add(model);
                    }
                    return _companiesViewModelList;
                }
            }
            return null;
        }


        public CompanyViewModel GetCompanyByID(int id)
        {
            CompanyViewModel model = new CompanyViewModel();
            using (ERPContext context = new ERPContext())
            {
                var company = context.Company.Find(id);
                if (company != null)
                {
                    model.CityID = company.CityId;
                    model.CompanyName = company.CompanyName;
                    model.PhoneNo = company.Phone;
                    model.Cities = getCities(company.CityId);
                    model.Address = company.Address;
                    model.WebsiteUrl = company.WebsiteURL;
                    model.CompanyID = company.CompanyId;
                    return model;
                }
            }
            return null;
        }
    }

}
