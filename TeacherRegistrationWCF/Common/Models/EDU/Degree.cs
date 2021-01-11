using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EDU
{
    public class Degree:ObjectModel<long>
    {
        public long PersonID { get; set; }
        public virtual Person Degree_Person { get; set; }
        public short GradeID { get; set; }
        public virtual Grade Degree_Grade { get; set; }
        public int FieldID { get; set; }
        public virtual Field Degree_Field { get; set; }
        public int SubFieldID { get; set; }
        public virtual SubField Degree_SubField { get; set; }
        //public int UniversityID { get; set; }
        //public virtual University Degree_University { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "University", ResourceType = typeof(SrtingResources.TextResources))]
        public string University { get; set; }
        public long CityID { get; set; }
        public virtual City Degree_City { get; set; }
        public int CountryID { get; set; }
        public virtual Country Degree_Country { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsFinalized { get; set; }
        public Degree()
        {
            IsFinalized = false;
        }

    }
    public class DegreeConfiguration : EntityTypeConfiguration<Degree>
    {
        public DegreeConfiguration()
        {
            ToTable("Degree", "EDU");

            HasRequired(m => m.Degree_Person)
               .WithMany(m => m.Person_Degree_List)
               .HasForeignKey(m => m.PersonID)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.Degree_Field)
               .WithMany(m => m.Field_Degree_List)
               .HasForeignKey(m => m.FieldID)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.Degree_SubField)
               .WithMany(m => m.SubField_Degree_List)
               .HasForeignKey(m => m.SubFieldID)
               .WillCascadeOnDelete(false);

            //HasRequired(m => m.Degree_University)
            //   .WithMany(m => m.University_Degree_List)
            //   .HasForeignKey(m => m.UniversityID)
            //   .WillCascadeOnDelete(false);

            HasRequired(m => m.Degree_City)
               .WithMany(m => m.City_Degree_List)
               .HasForeignKey(m => m.CityID)
               .WillCascadeOnDelete(false);


            HasRequired(m => m.Degree_Country)
               .WithMany(m => m.Country_Degree_List)
               .HasForeignKey(m => m.CountryID)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.Degree_Grade)
               .WithMany(m => m.Grade_Degree_List)
               .HasForeignKey(m => m.GradeID)
               .WillCascadeOnDelete(false);
        }
    }
}
