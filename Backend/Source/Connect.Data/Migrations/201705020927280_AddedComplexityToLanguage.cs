namespace Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedComplexityToLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "Complexity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "Complexity");
        }
    }
}
