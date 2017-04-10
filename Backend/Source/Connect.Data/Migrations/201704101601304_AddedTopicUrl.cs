namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTopicUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topic", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topic", "Url");
        }
    }
}
