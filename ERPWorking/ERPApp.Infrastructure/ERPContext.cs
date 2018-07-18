using System;
using System.Data.Entity;
using ERPApp.Core;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ERPApp.Infrastructure
{
  public  class ERPContext:DbContext
    {
        public ERPContext()
            : base("name=ERPConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            ERPInitilizeDB db=new ERPInitilizeDB();
            System.Data.Entity.Database.SetInitializer(db);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<PartyType> PartyType { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
        public DbSet<ItemCategoryMain> ItemCategoryMain { get; set; }
        public DbSet<ItemCategorySub> ItemCategorySub { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Item> Item { get; set; }

        public DbSet<POMain> POMain { get; set; }
        public DbSet<POSub> POSub { get; set; }
        public DbSet<POExpense> POExpense { get; set; }
        public DbSet<ReceiveMain> ReceiveMain { get; set; }
        public DbSet<ReceiveSub> ReceiveSub { get; set; }
        public DbSet<SaleMain> SaleMain { get; set; }
        public DbSet<SaleSub> SaleSub { get; set; }
        public DbSet<ReturnMain> ReturnMain { get; set; }
        public DbSet<ReturnSub> ReturnSub { get; set; }
        public DbSet<ItemPromotion> ItemPromotion { get; set; }
    }
}
