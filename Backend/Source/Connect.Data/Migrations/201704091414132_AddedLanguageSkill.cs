namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLanguageSkill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanguageSkill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.LanguageId)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LanguageSkill", "UserId", "dbo.User");
            DropForeignKey("dbo.LanguageSkill", "LanguageId", "dbo.Language");
            DropIndex("dbo.LanguageSkill", new[] { "UserId" });
            DropIndex("dbo.LanguageSkill", new[] { "LanguageId" });
            DropTable("dbo.LanguageSkill");
        }
    }
}
