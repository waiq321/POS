namespace ERPApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 50, unicode: false),
                        Location = c.String(maxLength: 200, unicode: false),
                        CityId = c.Int(nullable: false),
                        VoucherCounter = c.Int(nullable: false),
                        SaleCounter = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DeletedBy = c.String(maxLength: 256),
                        DeletedDate = c.DateTime(),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 15, unicode: false),
                        WebsiteURL = c.String(),
                        Address = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        TehsilId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.ExpenseType",
                c => new
                    {
                        ExpenseTypeId = c.Int(nullable: false, identity: true),
                        ExpenseTypeName = c.String(maxLength: 50, unicode: false),
                        Type = c.String(maxLength: 50, unicode: false),
                        IsCostPart = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 50),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseTypeId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.POExpense",
                c => new
                    {
                        POExpenseId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseDate = c.DateTime(nullable: false),
                        ExpenseBy = c.String(),
                        VoucherId = c.Int(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ExpenseTypeId = c.Int(nullable: false),
                        POId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.POExpenseId)
                .ForeignKey("dbo.ExpenseType", t => t.ExpenseTypeId)
                .ForeignKey("dbo.POMain", t => t.POId)
                .Index(t => t.ExpenseTypeId)
                .Index(t => t.POId);
            
            CreateTable(
                "dbo.POMain",
                c => new
                    {
                        POId = c.Int(nullable: false, identity: true),
                        PONO = c.String(maxLength: 50, unicode: false),
                        PODate = c.DateTime(nullable: false),
                        VID = c.Int(nullable: false),
                        PaymentMode = c.String(maxLength: 20, unicode: false),
                        ISApproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.POId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Party", t => t.PartyId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 10, unicode: false),
                        LastName = c.String(maxLength: 10, unicode: false),
                        CityId = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        RelationName = c.String(maxLength: 20, unicode: false),
                        NIC = c.String(maxLength: 15, unicode: false),
                        CellNo = c.String(maxLength: 15, unicode: false),
                        Address = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(maxLength: 25),
                        ItemName = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 100),
                        BarCode = c.String(maxLength: 100, unicode: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.ItemCategoryMain", t => t.CategoryId)
                .ForeignKey("dbo.ItemCategorySub", t => t.SubCategoryId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.ItemCategoryMain",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50, unicode: false),
                        Abb = c.String(maxLength: 10, unicode: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ItemCategorySub",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(maxLength: 50, unicode: false),
                        Abb = c.String(maxLength: 10, unicode: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.ItemCategoryMain", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemPromotion",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Discount = c.Single(nullable: false),
                        Description = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.POSub",
                c => new
                    {
                        POSId = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Single(nullable: false),
                        NetDicountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Expense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitExpense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        POId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.POSId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.POMain", t => t.POId)
                .Index(t => t.POId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReceiveSub",
                c => new
                    {
                        RSId = c.Int(nullable: false, identity: true),
                        ReceiveQty = c.Int(nullable: false),
                        SoldQty = c.Int(nullable: false),
                        ReturnQty = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(),
                        RMId = c.Int(nullable: false),
                        POSubId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RSId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.POSub", t => t.POSubId)
                .ForeignKey("dbo.ReceiveMain", t => t.RMId)
                .Index(t => t.RMId)
                .Index(t => t.POSubId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReceiveMain",
                c => new
                    {
                        RMId = c.Int(nullable: false, identity: true),
                        ReceiveBy = c.String(maxLength: 256),
                        ReceiveDate = c.DateTime(),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        POId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RMId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.POMain", t => t.POId)
                .Index(t => t.POId)
                .Index(t => t.DepartmentId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.SaleSub",
                c => new
                    {
                        SSId = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Single(nullable: false),
                        NetDicountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SMId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        RSId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SSId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.ReceiveSub", t => t.RSId)
                .ForeignKey("dbo.SaleMain", t => t.SMId)
                .Index(t => t.SMId)
                .Index(t => t.ItemId)
                .Index(t => t.RSId);
            
            CreateTable(
                "dbo.ReturnSub",
                c => new
                    {
                        RSId = c.Int(nullable: false, identity: true),
                        ReturnQty = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Single(nullable: false),
                        NetDicountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RMId = c.Int(nullable: false),
                        POSId = c.Int(nullable: false),
                        SSId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RSId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.POSub", t => t.POSId)
                .ForeignKey("dbo.ReturnMain", t => t.RMId)
                .ForeignKey("dbo.SaleSub", t => t.SSId)
                .Index(t => t.RMId)
                .Index(t => t.POSId)
                .Index(t => t.SSId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReturnMain",
                c => new
                    {
                        RMId = c.Int(nullable: false, identity: true),
                        ReturnBy = c.String(maxLength: 256),
                        ReturnDate = c.DateTime(),
                        ReturnType = c.String(maxLength: 50, unicode: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SMId = c.Int(nullable: false),
                        POId = c.Int(nullable: false),
                        VoucherId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RMId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Party", t => t.CustomerId)
                .ForeignKey("dbo.POMain", t => t.POId)
                .ForeignKey("dbo.SaleMain", t => t.SMId)
                .ForeignKey("dbo.Voucher", t => t.VoucherId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SMId)
                .Index(t => t.POId)
                .Index(t => t.VoucherId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Party",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        PartyName = c.String(maxLength: 50, unicode: false),
                        ContactPerson = c.String(maxLength: 50, unicode: false),
                        ContactNo = c.String(maxLength: 15, unicode: false),
                        Address = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        PartyTypeId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.PartyType", t => t.PartyTypeId)
                .Index(t => t.PartyTypeId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.PartyType",
                c => new
                    {
                        PartyTypeId = c.Int(nullable: false, identity: true),
                        PartyTypeName = c.String(maxLength: 50, unicode: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PartyTypeId);
            
            CreateTable(
                "dbo.SaleMain",
                c => new
                    {
                        SMId = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(maxLength: 50, unicode: false),
                        InvoiceDate = c.DateTime(),
                        InvoiceBy = c.String(maxLength: 256),
                        GST = c.Single(nullable: false),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        VoucherId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SMId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Party", t => t.CustomerId)
                .ForeignKey("dbo.Voucher", t => t.VoucherId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.VoucherId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        VoucherId = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        EntryBy = c.String(maxLength: 256),
                        EntryDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoucherId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branch", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.POExpense", "POId", "dbo.POMain");
            DropForeignKey("dbo.POMain", "PartyId", "dbo.Party");
            DropForeignKey("dbo.POMain", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.SaleSub", "SMId", "dbo.SaleMain");
            DropForeignKey("dbo.ReturnSub", "SSId", "dbo.SaleSub");
            DropForeignKey("dbo.ReturnSub", "RMId", "dbo.ReturnMain");
            DropForeignKey("dbo.ReturnMain", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.ReturnMain", "SMId", "dbo.SaleMain");
            DropForeignKey("dbo.ReturnMain", "POId", "dbo.POMain");
            DropForeignKey("dbo.ReturnMain", "CustomerId", "dbo.Party");
            DropForeignKey("dbo.SaleMain", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.Voucher", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Voucher", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.SaleMain", "CustomerId", "dbo.Party");
            DropForeignKey("dbo.SaleMain", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.SaleMain", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Party", "PartyTypeId", "dbo.PartyType");
            DropForeignKey("dbo.Party", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.ReturnMain", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.ReturnMain", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.ReturnSub", "POSId", "dbo.POSub");
            DropForeignKey("dbo.ReturnSub", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SaleSub", "RSId", "dbo.ReceiveSub");
            DropForeignKey("dbo.SaleSub", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ReceiveSub", "RMId", "dbo.ReceiveMain");
            DropForeignKey("dbo.ReceiveMain", "POId", "dbo.POMain");
            DropForeignKey("dbo.ReceiveMain", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.ReceiveMain", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.ReceiveSub", "POSubId", "dbo.POSub");
            DropForeignKey("dbo.ReceiveSub", "ItemId", "dbo.Items");
            DropForeignKey("dbo.POSub", "POId", "dbo.POMain");
            DropForeignKey("dbo.POSub", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.ItemPromotion", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPromotion", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.ItemPromotion", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Items", "SubCategoryId", "dbo.ItemCategorySub");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.ItemCategoryMain");
            DropForeignKey("dbo.ItemCategorySub", "CategoryId", "dbo.ItemCategoryMain");
            DropForeignKey("dbo.ItemCategoryMain", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Items", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Items", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Department", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.POMain", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.POExpense", "ExpenseTypeId", "dbo.ExpenseType");
            DropForeignKey("dbo.ExpenseType", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropIndex("dbo.Voucher", new[] { "DepartmentId" });
            DropIndex("dbo.Voucher", new[] { "BranchId" });
            DropIndex("dbo.SaleMain", new[] { "CustomerId" });
            DropIndex("dbo.SaleMain", new[] { "VoucherId" });
            DropIndex("dbo.SaleMain", new[] { "DepartmentId" });
            DropIndex("dbo.SaleMain", new[] { "BranchId" });
            DropIndex("dbo.Party", new[] { "BranchId" });
            DropIndex("dbo.Party", new[] { "PartyTypeId" });
            DropIndex("dbo.ReturnMain", new[] { "CustomerId" });
            DropIndex("dbo.ReturnMain", new[] { "VoucherId" });
            DropIndex("dbo.ReturnMain", new[] { "POId" });
            DropIndex("dbo.ReturnMain", new[] { "SMId" });
            DropIndex("dbo.ReturnMain", new[] { "DepartmentId" });
            DropIndex("dbo.ReturnMain", new[] { "BranchId" });
            DropIndex("dbo.ReturnSub", new[] { "ItemId" });
            DropIndex("dbo.ReturnSub", new[] { "SSId" });
            DropIndex("dbo.ReturnSub", new[] { "POSId" });
            DropIndex("dbo.ReturnSub", new[] { "RMId" });
            DropIndex("dbo.SaleSub", new[] { "RSId" });
            DropIndex("dbo.SaleSub", new[] { "ItemId" });
            DropIndex("dbo.SaleSub", new[] { "SMId" });
            DropIndex("dbo.ReceiveMain", new[] { "BranchId" });
            DropIndex("dbo.ReceiveMain", new[] { "DepartmentId" });
            DropIndex("dbo.ReceiveMain", new[] { "POId" });
            DropIndex("dbo.ReceiveSub", new[] { "ItemId" });
            DropIndex("dbo.ReceiveSub", new[] { "POSubId" });
            DropIndex("dbo.ReceiveSub", new[] { "RMId" });
            DropIndex("dbo.POSub", new[] { "ItemId" });
            DropIndex("dbo.POSub", new[] { "POId" });
            DropIndex("dbo.ItemPromotion", new[] { "ItemId" });
            DropIndex("dbo.ItemPromotion", new[] { "DepartmentId" });
            DropIndex("dbo.ItemPromotion", new[] { "BranchId" });
            DropIndex("dbo.ItemCategorySub", new[] { "CategoryId" });
            DropIndex("dbo.ItemCategoryMain", new[] { "BranchId" });
            DropIndex("dbo.Items", new[] { "ManufacturerId" });
            DropIndex("dbo.Items", new[] { "SubCategoryId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "DepartmentId" });
            DropIndex("dbo.Items", new[] { "BranchId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "BranchId" });
            DropIndex("dbo.Department", new[] { "BranchId" });
            DropIndex("dbo.POMain", new[] { "PartyId" });
            DropIndex("dbo.POMain", new[] { "DepartmentId" });
            DropIndex("dbo.POMain", new[] { "BranchId" });
            DropIndex("dbo.POExpense", new[] { "POId" });
            DropIndex("dbo.POExpense", new[] { "ExpenseTypeId" });
            DropIndex("dbo.ExpenseType", new[] { "CompanyId" });
            DropIndex("dbo.Company", new[] { "CityId" });
            DropIndex("dbo.Branch", new[] { "CompanyId" });
            DropTable("dbo.Voucher");
            DropTable("dbo.SaleMain");
            DropTable("dbo.PartyType");
            DropTable("dbo.Party");
            DropTable("dbo.ReturnMain");
            DropTable("dbo.ReturnSub");
            DropTable("dbo.SaleSub");
            DropTable("dbo.ReceiveMain");
            DropTable("dbo.ReceiveSub");
            DropTable("dbo.POSub");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.ItemPromotion");
            DropTable("dbo.ItemCategorySub");
            DropTable("dbo.ItemCategoryMain");
            DropTable("dbo.Items");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.POMain");
            DropTable("dbo.POExpense");
            DropTable("dbo.ExpenseType");
            DropTable("dbo.City");
            DropTable("dbo.Company");
            DropTable("dbo.Branch");
        }
    }
}
