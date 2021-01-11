namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressPhoneInWorkExp : DbMigration
    {
        public override void Up()
        {
            AddColumn("Job.WorkExp", "CompanyAddress", c => c.String());
            AddColumn("Job.WorkExp", "CompanyPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Job.WorkExp", "CompanyPhone");
            DropColumn("Job.WorkExp", "CompanyAddress");
        }
    }
}
