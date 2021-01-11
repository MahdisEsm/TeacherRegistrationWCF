using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EDU
{
    public class University:ObjectModel<int>
    {
        public string Name { get; set; }
        public long CityID { get; set; }
        public virtual City University_City { get; set; }
        public int CountryID { get; set; }
        public virtual Country University_Country { get; set; }
        //public virtual ICollection<Degree> University_Degree_List { get; set; }

    }
    public class UniversityConfiguration : EntityTypeConfiguration<University>
    {
        public UniversityConfiguration()
        {
            ToTable("University", "EDU");

            HasRequired(m => m.University_City)
               .WithMany(m => m.City_University_List)
               .HasForeignKey(m => m.CityID)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.University_Country)
               .WithMany(m => m.Country_University_List)
               .HasForeignKey(m => m.CountryID)
               .WillCascadeOnDelete(false);
        }
    }
}
