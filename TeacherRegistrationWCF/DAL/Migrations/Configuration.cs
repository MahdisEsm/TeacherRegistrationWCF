namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TeacherRegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.TeacherRegistrationContext";

        }

        protected override void Seed(DAL.TeacherRegistrationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Religion_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Religion() { ID = 1, Name = "اسلام" });
            context.Religion_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Religion() { ID = 2, Name = "مسیحی" });
            context.Religion_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Religion() { ID = 3, Name = "یهودی" });
            context.Religion_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Religion() { ID = 4, Name = "زرتشتی" });
            context.Country_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Country() { ID = 1, Name = "ایران" });
            context.Country_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Country() { ID = 2, Name = "افغانستان" });
            context.Country_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Country() { ID = 3, Name = "ترکیه" });
            context.Country_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.Country() { ID = 4, Name = "آلمان" });
            context.City_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.City() { ID = 1, Name = "تهران" ,CountryID=1});
            context.City_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.City() { ID = 2, Name = "شیراز", CountryID = 1 });
            context.City_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.City() { ID = 3, Name = "اصفهان", CountryID = 1 });
            context.City_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.City() { ID = 4, Name = "کابل", CountryID = 2 });
            context.PhoneType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.PhoneType() { ID = 1, Name = "همراه" });
            context.PhoneType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.PhoneType() { ID = 2, Name = "منزل" });
            context.PhoneType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.PhoneType() { ID = 3, Name = "کار" });
            context.EmailType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.EmailType() { ID = 1, Name = "شخصی" });
            context.EmailType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.EmailType() { ID = 2, Name = "کاری" });
            context.AddressType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.AddressType() { ID = 1, Name = "منزل" });
            context.AddressType_List.AddOrUpdate(m => m.ID, new Common.Models.Basic.AddressType() { ID = 2, Name = "محل کار" });
            context.Grade_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Grade() { ID = 1, Name = "کارشناسی" });
            context.Grade_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Grade() { ID = 2, Name = "کارشناسی ارشد" });
            context.Grade_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Grade() { ID = 3, Name = "دکتری" });
            context.Field_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Field() { ID = 1, Name = "کامپیوتر" });
            context.Field_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Field() { ID = 2, Name = "برق" });
            context.Field_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Field() { ID = 3, Name = "عمران" });
            context.Field_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Field() { ID = 4, Name = "فن آوری اطلاعات" });
            context.Field_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.Field() { ID = 5, Name = "سایر" });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 1, Name = "سخت افزار",FieldID=1 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 2, Name = "نرم افزار", FieldID = 1 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 3, Name = "مخابرات", FieldID = 2 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 4, Name = "کنترل", FieldID = 2 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 5, Name = "قدرت", FieldID = 2 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 6, Name = "عمران", FieldID = 3 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 7, Name = "فن آوری اطلاعات", FieldID = 4 });
            context.SubField_List.AddOrUpdate(m => m.ID, new Common.Models.EDU.SubField() { ID = 8, Name = "سایر", FieldID = 5 });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 1, Name = "مقدمات برنامه نویسی .Net"});
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 2, Name = "C#مقدماتی " });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 3, Name = "Advanced C#" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 4, Name = "MCSE 2019" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 5, Name = "Network+" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 6, Name = "FrontEnd Developer" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 7, Name = "FullStack .Net Developer" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 8, Name = "Java" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 9, Name = "VMware vSphere" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 10, Name = "PHP Developer" });
            context.SematecCourse_List.AddOrUpdate(m => m.ID, new Common.Models.TCH.SematecCourse() { ID = 11, Name = "Python Fundamentals" });
        }
    }
}
