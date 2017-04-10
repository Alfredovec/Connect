namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRecommendedTopics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topic", "Recommended", c => c.Boolean(nullable: false));
            AddColumn("dbo.Topic", "Relevant", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topic", "Relevant");
            DropColumn("dbo.Topic", "Recommended");
        }
    }
}
