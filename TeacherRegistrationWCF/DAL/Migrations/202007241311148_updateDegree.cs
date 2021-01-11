namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDegree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("EDU.Degree", "UniversityID", "EDU.University");
            DropIndex("EDU.Degree", new[] { "UniversityID" });
            AddColumn("EDU.Degree", "University", c => c.String());
            AddColumn("EDU.Degree", "CityID", c => c.Long(nullable: false));
            AddColumn("EDU.Degree", "CountryID", c => c.Int(nullable: false));
            CreateIndex("EDU.Degree", "CityID");
            CreateIndex("EDU.Degree", "CountryID");
            AddForeignKey("EDU.Degree", "CityID", "Basic.City", "ID");
            AddForeignKey("EDU.Degree", "CountryID", "Basic.Country", "ID");
            DropColumn("EDU.Degree", "UniversityID");
        }
        
        public override void Down()
        {
            AddColumn("EDU.Degree", "UniversityID", c => c.Int(nullable: false));
            DropForeignKey("EDU.Degree", "CountryID", "Basic.Country");
            DropForeignKey("EDU.Degree", "CityID", "Basic.City");
            DropIndex("EDU.Degree", new[] { "CountryID" });
            DropIndex("EDU.Degree", new[] { "CityID" });
            DropColumn("EDU.Degree", "CountryID");
            DropColumn("EDU.Degree", "CityID");
            DropColumn("EDU.Degree", "University");
            CreateIndex("EDU.Degree", "UniversityID");
            AddForeignKey("EDU.Degree", "UniversityID", "EDU.University", "ID");
        }
    }
}
