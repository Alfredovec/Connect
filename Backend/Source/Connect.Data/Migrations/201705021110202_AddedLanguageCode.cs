namespace Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedLanguageCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "Code");
        }
    }
}
