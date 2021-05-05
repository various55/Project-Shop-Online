namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 12, unicode: false),
                        Name = c.String(maxLength: 50),
                        CategoryID = c.Int(),
                        SupplierID = c.Int(),
                        UrlImage = c.String(maxLength: 256, unicode: false),
                        ImportPrice = c.Double(),
                        ExportPrice = c.Double(),
                        Description = c.String(unicode: false, storeType: "text"),
                        Discount = c.Double(),
                        TotalPurchase = c.Int(),
                        TotalInventory = c.Int(),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                        Suppelier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Suppeliers", t => t.Suppelier_ID)
                .Index(t => t.CategoryID)
                .Index(t => t.Suppelier_ID);
            
            CreateTable(
                "dbo.ImageDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        Description = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppeliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Andress = c.String(maxLength: 256),
                        Mobile = c.String(maxLength: 15, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Manager = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ConfirmStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50, unicode: false),
                        Mobile = c.String(maxLength: 15, unicode: false),
                        Title = c.String(maxLength: 50),
                        Content = c.String(unicode: false, storeType: "text"),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false, storeType: "text"),
                        CreatedBy = c.Int(),
                        CreateAt = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetai",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductDetaiID = c.Int(nullable: false),
                        Price = c.Double(),
                        Quantity = c.Int(),
                        Discount = c.Double(),
                        Total = c.Double(),
                        ProductDetail_ID = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductDetaiID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.ProductDetail", t => t.ProductDetail_ID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductDetail_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 256),
                        Mobile = c.String(maxLength: 15, unicode: false),
                        UserID = c.Int(),
                        Payment = c.String(maxLength: 50),
                        Total = c.Double(),
                        Fee = c.Double(),
                        Discount = c.Double(),
                        Status = c.Boolean(),
                        ConfirmStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ConfirmStatus", t => t.ConfirmStatusId)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ConfirmStatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 256),
                        Mobile = c.String(maxLength: 15, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        RoleID = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        SizeID = c.Int(),
                        ColorID = c.Int(),
                        UrlImage = c.String(maxLength: 256, unicode: false),
                        Invenory = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Sizes", t => t.SizeID)
                .Index(t => t.ProductID)
                .Index(t => t.SizeID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Content = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.Int(),
                        ModifyAt = c.DateTime(),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.ShopInformation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Logo = c.String(maxLength: 50, unicode: false),
                        TaxCode = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 50),
                        Moblie = c.String(maxLength: 15, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Facebook = c.String(maxLength: 50, unicode: false),
                        Instagram = c.String(maxLength: 50, unicode: false),
                        Twitter = c.String(maxLength: 50, unicode: false),
                        Youtube = c.String(maxLength: 50, unicode: false),
                        Zalo = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Statistical",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Title = c.String(maxLength: 256),
                        Content = c.String(unicode: false, storeType: "text"),
                        CreatedBy = c.Int(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TagProduct",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                        Detail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(),
                        CreateBy = c.Int(),
                        CreateAt = c.DateTime(),
                        Note = c.String(maxLength: 256),
                        Status = c.Boolean(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.OrderID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.TagProduct", "TagID", "dbo.Tags");
            DropForeignKey("dbo.TagProduct", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Posts", "user_ID", "dbo.Users");
            DropForeignKey("dbo.OrderDetai", "ProductDetail_ID", "dbo.ProductDetail");
            DropForeignKey("dbo.ProductDetail", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.ProductDetail", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductDetail", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderDetai", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ConfirmStatusId", "dbo.ConfirmStatus");
            DropForeignKey("dbo.Products", "Suppelier_ID", "dbo.Suppeliers");
            DropForeignKey("dbo.ImageDetail", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "User_ID" });
            DropIndex("dbo.Transactions", new[] { "OrderID" });
            DropIndex("dbo.TagProduct", new[] { "TagID" });
            DropIndex("dbo.TagProduct", new[] { "ProductID" });
            DropIndex("dbo.Posts", new[] { "user_ID" });
            DropIndex("dbo.ProductDetail", new[] { "ColorID" });
            DropIndex("dbo.ProductDetail", new[] { "SizeID" });
            DropIndex("dbo.ProductDetail", new[] { "ProductID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Orders", new[] { "ConfirmStatusId" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.OrderDetai", new[] { "ProductDetail_ID" });
            DropIndex("dbo.OrderDetai", new[] { "OrderID" });
            DropIndex("dbo.ImageDetail", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Suppelier_ID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Tags");
            DropTable("dbo.TagProduct");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Statistical");
            DropTable("dbo.ShopInformation");
            DropTable("dbo.Posts");
            DropTable("dbo.Sizes");
            DropTable("dbo.ProductDetail");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetai");
            DropTable("dbo.Logs");
            DropTable("dbo.Contacts");
            DropTable("dbo.ConfirmStatus");
            DropTable("dbo.Colors");
            DropTable("dbo.Suppeliers");
            DropTable("dbo.ImageDetail");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
