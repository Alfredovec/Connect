namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        FinishDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        UserMasterId = c.Int(nullable: false),
                        UserApprenticeId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .ForeignKey("dbo.User", t => t.UserApprenticeId)
                .ForeignKey("dbo.User", t => t.UserMasterId)
                .Index(t => t.UserMasterId)
                .Index(t => t.UserApprenticeId)
                .Index(t => t.TopicId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topic", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(),
                        AvatarUrl = c.String(),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        FromUserId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Created = c.DateTimeOffset(precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.FromUserId)
                .ForeignKey("dbo.Lesson", t => t.LessonId)
                .ForeignKey("dbo.User", t => t.ToUserId)
                .Index(t => t.LessonId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rate", "ToUserId", "dbo.User");
            DropForeignKey("dbo.Rate", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Rate", "FromUserId", "dbo.User");
            DropForeignKey("dbo.Lesson", "UserMasterId", "dbo.User");
            DropForeignKey("dbo.Lesson", "UserApprenticeId", "dbo.User");
            DropForeignKey("dbo.Lesson", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "ParentId", "dbo.Topic");
            DropForeignKey("dbo.Lesson", "LanguageId", "dbo.Language");
            DropIndex("dbo.Rate", new[] { "ToUserId" });
            DropIndex("dbo.Rate", new[] { "FromUserId" });
            DropIndex("dbo.Rate", new[] { "LessonId" });
            DropIndex("dbo.Topic", new[] { "ParentId" });
            DropIndex("dbo.Lesson", new[] { "LanguageId" });
            DropIndex("dbo.Lesson", new[] { "TopicId" });
            DropIndex("dbo.Lesson", new[] { "UserApprenticeId" });
            DropIndex("dbo.Lesson", new[] { "UserMasterId" });
            DropTable("dbo.Rate");
            DropTable("dbo.User");
            DropTable("dbo.Topic");
            DropTable("dbo.Lesson");
            DropTable("dbo.Language");
        }
    }
}
