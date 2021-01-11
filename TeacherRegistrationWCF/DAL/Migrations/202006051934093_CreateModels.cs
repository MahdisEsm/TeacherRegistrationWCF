namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Basic.Address",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Location = c.String(),
                        PersonID = c.Long(nullable: false),
                        CityID = c.Long(nullable: false),
                        AddressTypeID = c.Short(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.AddressType", t => t.AddressTypeID)
                .ForeignKey("Basic.City", t => t.CityID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.CityID)
                .Index(t => t.AddressTypeID);
            
            CreateTable(
                "Basic.AddressType",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Basic.City",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "Basic.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "CERT.Certificate",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersonID = c.Long(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Institude = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        OnlineLink = c.String(),
                        CountryID = c.Int(nullable: false),
                        CertPic = c.Binary(),
                        HasPaper = c.Boolean(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.Country", t => t.CountryID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "Basic.Person",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        NationalCode = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        BirthPlaceID = c.Long(nullable: false),
                        Gender = c.Byte(nullable: false),
                        ReligionID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        MaritalStatus = c.Boolean(nullable: false),
                        ChildNumber = c.Short(nullable: false),
                        PicFileName = c.String(),
                        PicFileContent = c.Binary(),
                        Username = c.String(),
                        Password = c.String(),
                        LastLoginDate = c.DateTime(),
                        ForcedChangePassword = c.Boolean(nullable: false),
                        ResumeContent = c.Binary(),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.City", t => t.BirthPlaceID)
                .ForeignKey("Basic.Religion", t => t.ReligionID)
                .ForeignKey("Basic.Country", t => t.CountryID)
                .Index(t => t.BirthPlaceID)
                .Index(t => t.ReligionID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "EDU.Degree",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersonID = c.Long(nullable: false),
                        GradeID = c.Short(nullable: false),
                        FieldID = c.Int(nullable: false),
                        SubFieldID = c.Int(nullable: false),
                        UniversityID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("EDU.Field", t => t.FieldID)
                .ForeignKey("EDU.Grade", t => t.GradeID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .ForeignKey("EDU.SubField", t => t.SubFieldID)
                .ForeignKey("EDU.University", t => t.UniversityID)
                .Index(t => t.PersonID)
                .Index(t => t.GradeID)
                .Index(t => t.FieldID)
                .Index(t => t.SubFieldID)
                .Index(t => t.UniversityID);
            
            CreateTable(
                "EDU.Field",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "EDU.SubField",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FieldID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("EDU.Field", t => t.FieldID)
                .Index(t => t.FieldID);
            
            CreateTable(
                "EDU.Grade",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "EDU.University",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Long(nullable: false),
                        CountryID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.City", t => t.CityID)
                .ForeignKey("Basic.Country", t => t.CountryID)
                .Index(t => t.CityID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "Basic.Email",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PersonID = c.Long(nullable: false),
                        EmailTypeID = c.Short(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.EmailType", t => t.EmailTypeID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.EmailTypeID);
            
            CreateTable(
                "Basic.EmailType",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "TCH.FavoriteCourse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Long(nullable: false),
                        SematecCourseID = c.Int(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .ForeignKey("TCH.SematecCourse", t => t.SematecCourseID)
                .Index(t => t.PersonID)
                .Index(t => t.SematecCourseID);
            
            CreateTable(
                "TCH.SematecCourse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Basic.Phone",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Number = c.String(),
                        PhoneTypeID = c.Short(nullable: false),
                        PersonID = c.Long(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.PhoneType", t => t.PhoneTypeID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PhoneTypeID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "Basic.PhoneType",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Basic.Religion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "TCH.TeachingExp",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersonID = c.Long(nullable: false),
                        Institude = c.String(),
                        Hours = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        CourseNames = c.String(),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "Job.WorkExp",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersonID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        Manager = c.String(),
                        Position = c.String(),
                        Duties = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Job.Company", t => t.CompanyID)
                .ForeignKey("Basic.Person", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.CompanyID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Basic.Person", "CountryID", "Basic.Country");
            DropForeignKey("Basic.City", "CountryID", "Basic.Country");
            DropForeignKey("CERT.Certificate", "PersonID", "Basic.Person");
            DropForeignKey("Job.WorkExp", "PersonID", "Basic.Person");
            DropForeignKey("Job.WorkExp", "CompanyID", "Job.Company");
            DropForeignKey("TCH.TeachingExp", "PersonID", "Basic.Person");
            DropForeignKey("Basic.Person", "ReligionID", "Basic.Religion");
            DropForeignKey("Basic.Phone", "PersonID", "Basic.Person");
            DropForeignKey("Basic.Phone", "PhoneTypeID", "Basic.PhoneType");
            DropForeignKey("TCH.FavoriteCourse", "SematecCourseID", "TCH.SematecCourse");
            DropForeignKey("TCH.FavoriteCourse", "PersonID", "Basic.Person");
            DropForeignKey("Basic.Email", "PersonID", "Basic.Person");
            DropForeignKey("Basic.Email", "EmailTypeID", "Basic.EmailType");
            DropForeignKey("EDU.Degree", "UniversityID", "EDU.University");
            DropForeignKey("EDU.University", "CountryID", "Basic.Country");
            DropForeignKey("EDU.University", "CityID", "Basic.City");
            DropForeignKey("EDU.Degree", "SubFieldID", "EDU.SubField");
            DropForeignKey("EDU.Degree", "PersonID", "Basic.Person");
            DropForeignKey("EDU.Degree", "GradeID", "EDU.Grade");
            DropForeignKey("EDU.Degree", "FieldID", "EDU.Field");
            DropForeignKey("EDU.SubField", "FieldID", "EDU.Field");
            DropForeignKey("Basic.Person", "BirthPlaceID", "Basic.City");
            DropForeignKey("Basic.Address", "PersonID", "Basic.Person");
            DropForeignKey("CERT.Certificate", "CountryID", "Basic.Country");
            DropForeignKey("Basic.Address", "CityID", "Basic.City");
            DropForeignKey("Basic.Address", "AddressTypeID", "Basic.AddressType");
            DropIndex("Job.WorkExp", new[] { "CompanyID" });
            DropIndex("Job.WorkExp", new[] { "PersonID" });
            DropIndex("TCH.TeachingExp", new[] { "PersonID" });
            DropIndex("Basic.Phone", new[] { "PersonID" });
            DropIndex("Basic.Phone", new[] { "PhoneTypeID" });
            DropIndex("TCH.FavoriteCourse", new[] { "SematecCourseID" });
            DropIndex("TCH.FavoriteCourse", new[] { "PersonID" });
            DropIndex("Basic.Email", new[] { "EmailTypeID" });
            DropIndex("Basic.Email", new[] { "PersonID" });
            DropIndex("EDU.University", new[] { "CountryID" });
            DropIndex("EDU.University", new[] { "CityID" });
            DropIndex("EDU.SubField", new[] { "FieldID" });
            DropIndex("EDU.Degree", new[] { "UniversityID" });
            DropIndex("EDU.Degree", new[] { "SubFieldID" });
            DropIndex("EDU.Degree", new[] { "FieldID" });
            DropIndex("EDU.Degree", new[] { "GradeID" });
            DropIndex("EDU.Degree", new[] { "PersonID" });
            DropIndex("Basic.Person", new[] { "CountryID" });
            DropIndex("Basic.Person", new[] { "ReligionID" });
            DropIndex("Basic.Person", new[] { "BirthPlaceID" });
            DropIndex("CERT.Certificate", new[] { "CountryID" });
            DropIndex("CERT.Certificate", new[] { "PersonID" });
            DropIndex("Basic.City", new[] { "CountryID" });
            DropIndex("Basic.Address", new[] { "AddressTypeID" });
            DropIndex("Basic.Address", new[] { "CityID" });
            DropIndex("Basic.Address", new[] { "PersonID" });
            DropTable("Job.Company");
            DropTable("Job.WorkExp");
            DropTable("TCH.TeachingExp");
            DropTable("Basic.Religion");
            DropTable("Basic.PhoneType");
            DropTable("Basic.Phone");
            DropTable("TCH.SematecCourse");
            DropTable("TCH.FavoriteCourse");
            DropTable("Basic.EmailType");
            DropTable("Basic.Email");
            DropTable("EDU.University");
            DropTable("EDU.Grade");
            DropTable("EDU.SubField");
            DropTable("EDU.Field");
            DropTable("EDU.Degree");
            DropTable("Basic.Person");
            DropTable("CERT.Certificate");
            DropTable("Basic.Country");
            DropTable("Basic.City");
            DropTable("Basic.AddressType");
            DropTable("Basic.Address");
        }
    }
}
