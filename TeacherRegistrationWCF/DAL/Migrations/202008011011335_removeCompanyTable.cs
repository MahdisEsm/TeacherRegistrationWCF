namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCompanyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Job.WorkExp", "CompanyID", "Job.Company");
            DropIndex("Job.WorkExp", new[] { "CompanyID" });
            AddColumn("Job.WorkExp", "CompanyName", c => c.String());
            DropColumn("Job.WorkExp", "CompanyID");
            DropTable("Job.Company");
        }
        
        public override void Down()
        {
            CreateTable(
                "Job.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("Job.WorkExp", "CompanyID", c => c.Int(nullable: false));
            DropColumn("Job.WorkExp", "CompanyName");
            CreateIndex("Job.WorkExp", "CompanyID");
            AddForeignKey("Job.WorkExp", "CompanyID", "Job.Company", "ID");
        }
    }
}
