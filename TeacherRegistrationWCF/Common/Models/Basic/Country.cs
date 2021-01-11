using Common.Models.CERT;
using Common.Models.EDU;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class Country:Common.Models.ObjectModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<City> Country_City_List { get; set; }
        public virtual ICollection<Person> Country_Person_List { get; set; }
        public virtual ICollection<University> Country_University_List { get; set; }
        public virtual ICollection<Degree> Country_Degree_List { get; set; }
        public virtual ICollection<Certificate> Country_Certificate_List { get; set; }
    }
    public class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Country", "Basic");
            HasMany(m => m.Country_City_List)
                .WithRequired(m => m.City_Country)
                .HasForeignKey(m => m.CountryID)
                .WillCascadeOnDelete(false);
            HasMany(m => m.Country_Person_List)
                .WithRequired(m => m.Person_Country)
                .HasForeignKey(m => m.CountryID)
                .WillCascadeOnDelete(false);
        }
    }
}
