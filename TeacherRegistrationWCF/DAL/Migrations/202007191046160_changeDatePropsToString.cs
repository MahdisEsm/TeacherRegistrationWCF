namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatePropsToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("CERT.Certificate", "Date", c => c.String());
            AlterColumn("Basic.Person", "BirthDate", c => c.String());
            AlterColumn("EDU.Degree", "FromDate", c => c.String());
            AlterColumn("EDU.Degree", "ToDate", c => c.String());
            AlterColumn("TCH.TeachingExp", "FromDate", c => c.String());
            AlterColumn("TCH.TeachingExp", "ToDate", c => c.String());
            AlterColumn("Job.WorkExp", "FromDate", c => c.String());
            AlterColumn("Job.WorkExp", "ToDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Job.WorkExp", "ToDate", c => c.DateTime(nullable: false));
            AlterColumn("Job.WorkExp", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("TCH.TeachingExp", "ToDate", c => c.DateTime(nullable: false));
            AlterColumn("TCH.TeachingExp", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("EDU.Degree", "ToDate", c => c.DateTime(nullable: false));
            AlterColumn("EDU.Degree", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("Basic.Person", "BirthDate", c => c.DateTime());
            AlterColumn("CERT.Certificate", "Date", c => c.DateTime(nullable: false));
        }
    }
}
