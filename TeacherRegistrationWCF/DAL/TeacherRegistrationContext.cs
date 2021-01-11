using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeacherRegistrationContext : System.Data.Entity.DbContext
    {
       
        public System.Data.Entity.DbSet<Common.Models.Basic.Person> Person_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.Phone> Phone_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.Email> Email_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.Address> Address_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.EDU.Degree> Degree_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.EDU.Grade> Grade_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.EDU.Field> Field_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.EDU.SubField> SubField_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.EDU.University> University_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Job.WorkExp> WorkExp_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.TCH.TeachingExp> TeachingExp_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.CERT.Certificate> Certificate_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.TCH.FavoriteCourse> FavoriteCourse_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.TCH.SematecCourse> SematecCourse_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.Religion> Religion_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.Country> Country_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.City> City_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.PhoneType> PhoneType_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.AddressType> AddressType_List { get; set; }
        public System.Data.Entity.DbSet<Common.Models.Basic.EmailType> EmailType_List { get; set; }

        public TeacherRegistrationContext() : base("TeacherRegistrationContext")
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<TeacherRegistrationContext, DAL.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Common.Models.Basic.PersonConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.AddressConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.AddressTypeConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.CityConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.CountryConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.EmailConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.EmailTypeConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.PhoneConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.PhoneTypeConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Basic.ReligionConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.CERT.CertificateConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.EDU.DegreeConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.EDU.FieldConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.EDU.GradeConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.EDU.SubFieldConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.EDU.UniversityConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.Job.WorkExpConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.TCH.FavoriteCourseConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.TCH.SematecCourseConfiguration());
            modelBuilder.Configurations.Add(new Common.Models.TCH.TeachingExpConfiguration());


            base.OnModelCreating(modelBuilder);
        }


    }
}
