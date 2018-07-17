namespace ERPApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
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
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
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
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
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
                "dbo.ExpenseTypes",
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
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.POExpenses",
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
                .ForeignKey("dbo.ExpenseTypes", t => t.ExpenseTypeId)
                .ForeignKey("dbo.POMains", t => t.POId)
                .Index(t => t.ExpenseTypeId)
                .Index(t => t.POId);
            
            CreateTable(
                "dbo.POMains",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Parties", t => t.PartyId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Departments",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Employees",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.ItemCategoryMains", t => t.CategoryId)
                .ForeignKey("dbo.ItemCategorySubs", t => t.SubCategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.ItemCategoryMains",
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
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ItemCategorySubs",
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
                .ForeignKey("dbo.ItemCategoryMains", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemPromotions",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Manufacturers",
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
                "dbo.POSubs",
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
                .ForeignKey("dbo.POMains", t => t.POId)
                .Index(t => t.POId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReceiveSubs",
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
                .ForeignKey("dbo.POSubs", t => t.POSubId)
                .ForeignKey("dbo.ReceiveMains", t => t.RMId)
                .Index(t => t.RMId)
                .Index(t => t.POSubId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReceiveMains",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.POMains", t => t.POId)
                .Index(t => t.POId)
                .Index(t => t.DepartmentId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.SaleSubs",
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
                .ForeignKey("dbo.ReceiveSubs", t => t.RSId)
                .ForeignKey("dbo.SaleMains", t => t.SMId)
                .Index(t => t.SMId)
                .Index(t => t.ItemId)
                .Index(t => t.RSId);
            
            CreateTable(
                "dbo.ReturnSubs",
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
                .ForeignKey("dbo.POSubs", t => t.POSId)
                .ForeignKey("dbo.ReturnMains", t => t.RMId)
                .ForeignKey("dbo.SaleSubs", t => t.SSId)
                .Index(t => t.RMId)
                .Index(t => t.POSId)
                .Index(t => t.SSId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ReturnMains",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Parties", t => t.CustomerId)
                .ForeignKey("dbo.POMains", t => t.POId)
                .ForeignKey("dbo.SaleMains", t => t.SMId)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SMId)
                .Index(t => t.POId)
                .Index(t => t.VoucherId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Parties",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.PartyTypes", t => t.PartyTypeId)
                .Index(t => t.PartyTypeId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.PartyTypes",
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
                "dbo.SaleMains",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Parties", t => t.CustomerId)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.VoucherId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Vouchers",
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
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.POExpenses", "POId", "dbo.POMains");
            DropForeignKey("dbo.POMains", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.POMains", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SaleSubs", "SMId", "dbo.SaleMains");
            DropForeignKey("dbo.ReturnSubs", "SSId", "dbo.SaleSubs");
            DropForeignKey("dbo.ReturnSubs", "RMId", "dbo.ReturnMains");
            DropForeignKey("dbo.ReturnMains", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.ReturnMains", "SMId", "dbo.SaleMains");
            DropForeignKey("dbo.ReturnMains", "POId", "dbo.POMains");
            DropForeignKey("dbo.ReturnMains", "CustomerId", "dbo.Parties");
            DropForeignKey("dbo.SaleMains", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.Vouchers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Vouchers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.SaleMains", "CustomerId", "dbo.Parties");
            DropForeignKey("dbo.SaleMains", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SaleMains", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Parties", "PartyTypeId", "dbo.PartyTypes");
            DropForeignKey("dbo.Parties", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ReturnMains", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ReturnMains", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ReturnSubs", "POSId", "dbo.POSubs");
            DropForeignKey("dbo.ReturnSubs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SaleSubs", "RSId", "dbo.ReceiveSubs");
            DropForeignKey("dbo.SaleSubs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ReceiveSubs", "RMId", "dbo.ReceiveMains");
            DropForeignKey("dbo.ReceiveMains", "POId", "dbo.POMains");
            DropForeignKey("dbo.ReceiveMains", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ReceiveMains", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ReceiveSubs", "POSubId", "dbo.POSubs");
            DropForeignKey("dbo.ReceiveSubs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.POSubs", "POId", "dbo.POMains");
            DropForeignKey("dbo.POSubs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.ItemPromotions", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPromotions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ItemPromotions", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Items", "SubCategoryId", "dbo.ItemCategorySubs");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.ItemCategoryMains");
            DropForeignKey("dbo.ItemCategorySubs", "CategoryId", "dbo.ItemCategoryMains");
            DropForeignKey("dbo.ItemCategoryMains", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ItemCategoryMains", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Items", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Items", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Departments", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.POMains", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.POExpenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropForeignKey("dbo.ExpenseTypes", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropIndex("dbo.Vouchers", new[] { "DepartmentId" });
            DropIndex("dbo.Vouchers", new[] { "BranchId" });
            DropIndex("dbo.SaleMains", new[] { "CustomerId" });
            DropIndex("dbo.SaleMains", new[] { "VoucherId" });
            DropIndex("dbo.SaleMains", new[] { "DepartmentId" });
            DropIndex("dbo.SaleMains", new[] { "BranchId" });
            DropIndex("dbo.Parties", new[] { "BranchId" });
            DropIndex("dbo.Parties", new[] { "PartyTypeId" });
            DropIndex("dbo.ReturnMains", new[] { "CustomerId" });
            DropIndex("dbo.ReturnMains", new[] { "VoucherId" });
            DropIndex("dbo.ReturnMains", new[] { "POId" });
            DropIndex("dbo.ReturnMains", new[] { "SMId" });
            DropIndex("dbo.ReturnMains", new[] { "DepartmentId" });
            DropIndex("dbo.ReturnMains", new[] { "BranchId" });
            DropIndex("dbo.ReturnSubs", new[] { "ItemId" });
            DropIndex("dbo.ReturnSubs", new[] { "SSId" });
            DropIndex("dbo.ReturnSubs", new[] { "POSId" });
            DropIndex("dbo.ReturnSubs", new[] { "RMId" });
            DropIndex("dbo.SaleSubs", new[] { "RSId" });
            DropIndex("dbo.SaleSubs", new[] { "ItemId" });
            DropIndex("dbo.SaleSubs", new[] { "SMId" });
            DropIndex("dbo.ReceiveMains", new[] { "BranchId" });
            DropIndex("dbo.ReceiveMains", new[] { "DepartmentId" });
            DropIndex("dbo.ReceiveMains", new[] { "POId" });
            DropIndex("dbo.ReceiveSubs", new[] { "ItemId" });
            DropIndex("dbo.ReceiveSubs", new[] { "POSubId" });
            DropIndex("dbo.ReceiveSubs", new[] { "RMId" });
            DropIndex("dbo.POSubs", new[] { "ItemId" });
            DropIndex("dbo.POSubs", new[] { "POId" });
            DropIndex("dbo.ItemPromotions", new[] { "ItemId" });
            DropIndex("dbo.ItemPromotions", new[] { "DepartmentId" });
            DropIndex("dbo.ItemPromotions", new[] { "BranchId" });
            DropIndex("dbo.ItemCategorySubs", new[] { "CategoryId" });
            DropIndex("dbo.ItemCategoryMains", new[] { "DepartmentId" });
            DropIndex("dbo.ItemCategoryMains", new[] { "BranchId" });
            DropIndex("dbo.Items", new[] { "ManufacturerId" });
            DropIndex("dbo.Items", new[] { "SubCategoryId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "DepartmentId" });
            DropIndex("dbo.Items", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Departments", new[] { "BranchId" });
            DropIndex("dbo.POMains", new[] { "PartyId" });
            DropIndex("dbo.POMains", new[] { "DepartmentId" });
            DropIndex("dbo.POMains", new[] { "BranchId" });
            DropIndex("dbo.POExpenses", new[] { "POId" });
            DropIndex("dbo.POExpenses", new[] { "ExpenseTypeId" });
            DropIndex("dbo.ExpenseTypes", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Branches", new[] { "CompanyId" });
            DropTable("dbo.Vouchers");
            DropTable("dbo.SaleMains");
            DropTable("dbo.PartyTypes");
            DropTable("dbo.Parties");
            DropTable("dbo.ReturnMains");
            DropTable("dbo.ReturnSubs");
            DropTable("dbo.SaleSubs");
            DropTable("dbo.ReceiveMains");
            DropTable("dbo.ReceiveSubs");
            DropTable("dbo.POSubs");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.ItemPromotions");
            DropTable("dbo.ItemCategorySubs");
            DropTable("dbo.ItemCategoryMains");
            DropTable("dbo.Items");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.POMains");
            DropTable("dbo.POExpenses");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.Companies");
            DropTable("dbo.Branches");
        }
    }
}
