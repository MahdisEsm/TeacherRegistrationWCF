namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModelDateAlowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Basic.Person", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Basic.Person", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
