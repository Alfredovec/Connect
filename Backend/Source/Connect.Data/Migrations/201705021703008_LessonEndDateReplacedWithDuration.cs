namespace Connect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonEndDateReplacedWithDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Lesson", "FinishDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lesson", "FinishDateTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Lesson", "Duration");
        }
    }
}
