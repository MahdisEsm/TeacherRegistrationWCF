namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResumeFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("Basic.Person", "ResumeFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Basic.Person", "ResumeFileName");
        }
    }
}
