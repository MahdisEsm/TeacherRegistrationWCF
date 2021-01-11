using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Common.Models.EDU;
using Common.Models.Job;
using Common.Models.CERT;
using Common.Models.TCH;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models.Basic
{

    public class Person : Common.Models.ObjectModel<long>
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "FirstName", ResourceType = typeof(SrtingResources.TextResources))]
        public string FirstName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "LastName", ResourceType = typeof(SrtingResources.TextResources))]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "NationalCode", ResourceType = typeof(SrtingResources.TextResources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        public string NationalCode { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "BirthDate", ResourceType = typeof(SrtingResources.TextResources))]
        public string BirthDate { get; set; }
        public long BirthPlaceID { get; set; }
        public virtual City Person_City { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Gender", ResourceType = typeof(SrtingResources.TextResources))]
        public byte Gender { get; set; }
        public virtual Religion Person_Religion { get; set; }
        public int ReligionID { get; set; }
        public virtual Country Person_Country { get; set; }
        public int CountryID { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "MaritalStatus", ResourceType = typeof(SrtingResources.TextResources))]
        public bool MaritalStatus { get; set; }
        public short ChildNumber { get; set; }
        public string PicFileName { get; set; }
        public byte[] PicFileContent { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Username", ResourceType = typeof(SrtingResources.TextResources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        public string Username { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Password", ResourceType = typeof(SrtingResources.TextResources))]
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool ForcedChangePassword { get; set; }
        public byte[] ResumeContent { get; set; }
        public string ResumeFileName { get; set; }
        public bool IsFinalized { get; set; }
        public virtual ICollection<Address> Person_Address_List { get; set; }
        public virtual ICollection<Email> Person_Email_List { get; set; }
        public virtual ICollection<Phone> Person_Phone_List { get; set; }
        public virtual ICollection<Degree> Person_Degree_List { get; set; }
        public virtual ICollection<WorkExp> Person_WorkExp_List { get; set; }
        public virtual ICollection<Certificate> Person_Certificate_List { get; set; }
        public virtual ICollection<TeachingExp> Person_TeachingExp_List { get; set; }
        public virtual ICollection<FavoriteCourse> Person_FavoriteCourse_List { get; set; }
        public Person()
        {
            ForcedChangePassword = true;
            IsFinalized = false;
        }
    }

    public class PersonConfiguration: EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("Person", "Basic");
            HasMany(m => m.Person_Address_List)
                .WithRequired(m => m.Address_Person)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);
            HasMany(m => m.Person_Phone_List)
                .WithRequired(m => m.Phone_Person)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.Person_City)
                .WithMany(m => m.City_Person_List)
                .HasForeignKey(m => m.BirthPlaceID)
                .WillCascadeOnDelete(false);

            HasIndex(m => m.NationalCode)
                .IsUnique()
                .HasName("UK_Person_NationalCode");

            HasIndex(m => m.Username)
                .IsUnique()
                .HasName("UK_Person_Username");



        }
    }
}
