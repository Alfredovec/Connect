namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserWishedSkills : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LanguageSkill", new[] { "UserId" });
            AddColumn("dbo.LanguageSkill", "UserWishedId", c => c.Int());
            AlterColumn("dbo.LanguageSkill", "UserId", c => c.Int());
            CreateIndex("dbo.LanguageSkill", "UserId");
            CreateIndex("dbo.LanguageSkill", "UserWishedId");
            AddForeignKey("dbo.LanguageSkill", "UserWishedId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LanguageSkill", "UserWishedId", "dbo.User");
            DropIndex("dbo.LanguageSkill", new[] { "UserWishedId" });
            DropIndex("dbo.LanguageSkill", new[] { "UserId" });
            AlterColumn("dbo.LanguageSkill", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.LanguageSkill", "UserWishedId");
            CreateIndex("dbo.LanguageSkill", "UserId");
        }
    }
}
