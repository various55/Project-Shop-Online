namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasev1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "SupplierID");
            DropColumn("dbo.DiscountCodes", "CreatedBy");
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.Transactions", "CreateBy");
            RenameColumn(table: "dbo.Products", name: "Suppelier_ID1", newName: "SupplierID");
            RenameColumn(table: "dbo.DiscountCodes", name: "user_ID", newName: "CreatedBy");
            RenameColumn(table: "dbo.Posts", name: "user_ID", newName: "CreatedBy");
            RenameColumn(table: "dbo.Transactions", name: "User_ID", newName: "CreateBy");
            RenameIndex(table: "dbo.Products", name: "IX_Suppelier_ID1", newName: "IX_SupplierID");
            RenameIndex(table: "dbo.DiscountCodes", name: "IX_user_ID", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Posts", name: "IX_user_ID", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Transactions", name: "IX_User_ID", newName: "IX_CreateBy");
            DropColumn("dbo.Products", "Suppelier_ID");
            DropColumn("dbo.Orders", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "User_ID", c => c.Int());
            AddColumn("dbo.Products", "Suppelier_ID", c => c.Int());
            RenameIndex(table: "dbo.Transactions", name: "IX_CreateBy", newName: "IX_User_ID");
            RenameIndex(table: "dbo.Posts", name: "IX_CreatedBy", newName: "IX_user_ID");
            RenameIndex(table: "dbo.DiscountCodes", name: "IX_CreatedBy", newName: "IX_user_ID");
            RenameIndex(table: "dbo.Products", name: "IX_SupplierID", newName: "IX_Suppelier_ID1");
            RenameColumn(table: "dbo.Transactions", name: "CreateBy", newName: "User_ID");
            RenameColumn(table: "dbo.Posts", name: "CreatedBy", newName: "user_ID");
            RenameColumn(table: "dbo.DiscountCodes", name: "CreatedBy", newName: "user_ID");
            RenameColumn(table: "dbo.Products", name: "SupplierID", newName: "Suppelier_ID1");
            AddColumn("dbo.Transactions", "CreateBy", c => c.Int());
            AddColumn("dbo.Posts", "CreatedBy", c => c.Int());
            AddColumn("dbo.DiscountCodes", "CreatedBy", c => c.Int());
            AddColumn("dbo.Products", "SupplierID", c => c.Int());
        }
    }
}
