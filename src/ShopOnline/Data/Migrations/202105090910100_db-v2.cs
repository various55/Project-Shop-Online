namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Posts", "Image", c => c.String(maxLength: 256));
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "Image", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 50));
        }
    }
}
