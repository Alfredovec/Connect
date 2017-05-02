namespace Connect.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedLessonRoomId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "RoomId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lesson", "RoomId");
        }
    }
}
