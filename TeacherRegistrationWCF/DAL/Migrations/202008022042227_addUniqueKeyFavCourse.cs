namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUniqueKeyFavCourse : DbMigration
    {
        public override void Up()
        {
            DropIndex("TCH.FavoriteCourse", new[] { "PersonID" });
            DropIndex("TCH.FavoriteCourse", new[] { "SematecCourseID" });
            CreateIndex("TCH.FavoriteCourse", new[] { "PersonID", "SematecCourseID" }, unique: true, name: "IX_Person_SematecCourse");
        }
        
        public override void Down()
        {
            DropIndex("TCH.FavoriteCourse", "IX_Person_SematecCourse");
            CreateIndex("TCH.FavoriteCourse", "SematecCourseID");
            CreateIndex("TCH.FavoriteCourse", "PersonID");
        }
    }
}
