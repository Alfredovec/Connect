namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendsMirgation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        LeftUserId = c.Int(nullable: false),
                        RightUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LeftUserId, t.RightUserId })
                .ForeignKey("dbo.User", t => t.LeftUserId)
                .ForeignKey("dbo.User", t => t.RightUserId)
                .Index(t => t.LeftUserId)
                .Index(t => t.RightUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "RightUserId", "dbo.User");
            DropForeignKey("dbo.Friends", "LeftUserId", "dbo.User");
            DropIndex("dbo.Friends", new[] { "RightUserId" });
            DropIndex("dbo.Friends", new[] { "LeftUserId" });
            DropTable("dbo.Friends");
        }
    }
}
