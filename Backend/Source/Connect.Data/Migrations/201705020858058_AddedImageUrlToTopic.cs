namespace Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlToTopic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topic", "SourceUrl", c => c.String());
            AddColumn("dbo.Topic", "ImageUrl", c => c.String());
            DropColumn("dbo.Topic", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topic", "Url", c => c.String());
            DropColumn("dbo.Topic", "ImageUrl");
            DropColumn("dbo.Topic", "SourceUrl");
        }
    }
}
