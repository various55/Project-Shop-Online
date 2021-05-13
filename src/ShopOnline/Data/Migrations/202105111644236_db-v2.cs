namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DiscountCodes", newName: "DiscountCode");
            AddColumn("dbo.DiscountCode", "Discount", c => c.Int());
            AlterColumn("dbo.Products", "Discount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Discount", c => c.Double());
            DropColumn("dbo.DiscountCode", "Discount");
            RenameTable(name: "dbo.DiscountCode", newName: "DiscountCodes");
        }
    }
}
