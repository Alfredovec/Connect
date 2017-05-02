namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlToLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "ImageUrl");
        }
    }
}
