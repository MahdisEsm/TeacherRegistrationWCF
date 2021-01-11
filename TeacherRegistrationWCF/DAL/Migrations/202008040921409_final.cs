namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Basic.Address", "Location", c => c.String(nullable: false));
            AlterColumn("CERT.Certificate", "Name", c => c.String(nullable: false));
            AlterColumn("Basic.Person", "FirstName", c => c.String(nullable: false));
            AlterColumn("Basic.Person", "LastName", c => c.String(nullable: false));
            AlterColumn("Basic.Person", "NationalCode", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Basic.Person", "BirthDate", c => c.String(nullable: false));
            AlterColumn("Basic.Person", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Basic.Person", "Password", c => c.String(nullable: false));
            AlterColumn("EDU.Degree", "University", c => c.String(nullable: false));
            AlterColumn("Basic.Email", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("Basic.Phone", "Number", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("TCH.TeachingExp", "Institude", c => c.String(nullable: false));
            AlterColumn("TCH.TeachingExp", "FromDate", c => c.String(nullable: false));
            AlterColumn("TCH.TeachingExp", "ToDate", c => c.String(nullable: false));
            AlterColumn("TCH.TeachingExp", "CourseNames", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "CompanyName", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "CompanyAddress", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "CompanyPhone", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "Position", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "Duties", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "FromDate", c => c.String(nullable: false));
            AlterColumn("Job.WorkExp", "ToDate", c => c.String(nullable: false));
            CreateIndex("Basic.Person", "NationalCode", unique: true, name: "UK_Person_NationalCode");
            CreateIndex("Basic.Person", "Username", unique: true, name: "UK_Person_Username");
            CreateIndex("Basic.Email", "Name", unique: true, name: "UK_Email_Name");
            CreateIndex("Basic.Phone", "Number", unique: true, name: "UK_Phone_Number");
        }
        
        public override void Down()
        {
            DropIndex("Basic.Phone", "UK_Phone_Number");
            DropIndex("Basic.Email", "UK_Email_Name");
            DropIndex("Basic.Person", "UK_Person_Username");
            DropIndex("Basic.Person", "UK_Person_NationalCode");
            AlterColumn("Job.WorkExp", "ToDate", c => c.String());
            AlterColumn("Job.WorkExp", "FromDate", c => c.String());
            AlterColumn("Job.WorkExp", "Duties", c => c.String());
            AlterColumn("Job.WorkExp", "Position", c => c.String());
            AlterColumn("Job.WorkExp", "CompanyPhone", c => c.String());
            AlterColumn("Job.WorkExp", "CompanyAddress", c => c.String());
            AlterColumn("Job.WorkExp", "CompanyName", c => c.String());
            AlterColumn("TCH.TeachingExp", "CourseNames", c => c.String());
            AlterColumn("TCH.TeachingExp", "ToDate", c => c.String());
            AlterColumn("TCH.TeachingExp", "FromDate", c => c.String());
            AlterColumn("TCH.TeachingExp", "Institude", c => c.String());
            AlterColumn("Basic.Phone", "Number", c => c.String());
            AlterColumn("Basic.Email", "Name", c => c.String());
            AlterColumn("EDU.Degree", "University", c => c.String());
            AlterColumn("Basic.Person", "Password", c => c.String());
            AlterColumn("Basic.Person", "Username", c => c.String());
            AlterColumn("Basic.Person", "BirthDate", c => c.String());
            AlterColumn("Basic.Person", "NationalCode", c => c.String());
            AlterColumn("Basic.Person", "LastName", c => c.String());
            AlterColumn("Basic.Person", "FirstName", c => c.String());
            AlterColumn("CERT.Certificate", "Name", c => c.String());
            AlterColumn("Basic.Address", "Location", c => c.String());
        }
    }
}
