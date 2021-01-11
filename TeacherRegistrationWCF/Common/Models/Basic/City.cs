using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Common.Models.EDU;

namespace Common.Models.Basic
{
    public class City:Common.Models.ObjectModel<long>
    {
        public string Name { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country City_Country { get; set; }
        public int CountryID { get; set; }
        public virtual ICollection<Address> Address_List { get; set; }
        public virtual ICollection<University> City_University_List { get; set; }
        public virtual ICollection<Degree> City_Degree_List { get; set; }
        public virtual ICollection<Person> City_Person_List { get; set; }
    }
    public class CityConfiguration: EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("City", "Basic");
            HasMany(m => m.Address_List)
                .WithRequired(m => m.Address_City)
                .HasForeignKey(m => m.CityID)
                .WillCascadeOnDelete(false);
        }
    }
}
