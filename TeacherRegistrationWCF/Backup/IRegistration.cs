using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace TeacherRegistrationWCF
{
    [ServiceContract]
    public interface IRegistration
    {
      
        
        [OperationContract]
        ICollection<Person>  GetAllPerson();
        
        [OperationContract]
        ICollection<EmailType> GetAllEmailType();
     
        [OperationContract]
        ICollection<PhoneType> GetAllPhoneType();
        
        [OperationContract]
        ICollection<AddressType> GetAllAddressType();
    
        [OperationContract]
        ICollection<Phone> GetAllPhone();
        
        [OperationContract]
        ICollection<Email> GetAllEmail();
  
        [OperationContract]
        ICollection<Address> GetAllAddress();
        [OperationContract]
        void SubmitPersonalInfoAsync(Person person, List<Phone> phones, List<Email> emails, List<Address> addresses);
        [OperationContract]
        ICollection<City> GetAllCity();
        [OperationContract]
        ICollection<Country> GetAllCountry();
        [OperationContract]
        ICollection<Religion> GetAllReligion();
        [OperationContract]
        bool Login(string username,string password);
    }

    [DataContract]
    public class Person
    {
        private long _ID;
        private string _firstName;
        private string _lastName;
        private string _nationalCode;
        private DateTime _birthDate;
        private byte _gender;
        private string _picFileName;
        private byte[] _picFileContent;
        private string _username;
        private string _password;
        private long _birthPlaceID;
        private int _religionID;
        private bool _maritalStatus;
        private short _childNumber;
        private int _countryID;
        private byte[] _resumeContent;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }

        [DataMember]
        public string FirstName { get => _firstName; set => _firstName = value; }
        [DataMember]
        public string LastName { get => _lastName; set => _lastName = value; }
        [DataMember]
        public string NationalCode { get => _nationalCode; set => _nationalCode = value; }
        [DataMember]
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        [DataMember]
        public byte Gender { get => _gender; set => _gender = value; }
        [DataMember]
        public string PicFileName { get => _picFileName; set => _picFileName = value; }
        [DataMember]
        public byte[] PicFileContent { get => _picFileContent; set => _picFileContent = value; }
        [DataMember]
        public string Username { get => _username; set => _username = value; }
        [DataMember]
        public string Password { get => _password; set => _password = value; }
      
        [DataMember]
        public short ChildNumber { get => _childNumber; set => _childNumber = value; }
        [DataMember]
        public long BirthPlaceID { get => _birthPlaceID; set => _birthPlaceID = value; }
        [DataMember]
        public int ReligionID { get => _religionID; set => _religionID = value; }
        [DataMember]
        public bool MaritalStatus { get => _maritalStatus; set => _maritalStatus = value; }
        [DataMember]
        public int CountryID { get => _countryID; set => _countryID = value; }
        [DataMember]
        public byte[] ResumeContent { get => _resumeContent; set => _resumeContent = value; }
    }
    [DataContract]
    public class Phone
    {
        private long _ID;
        private String _number;
        private short _phoneTypeID;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Number { get => _number; set => _number = value; }
        [DataMember]
        public short PhoneTypeID { get => _phoneTypeID; set => _phoneTypeID = value; }
     

    }

    [DataContract]
    public class Email
    {
        private long _ID;
        private string _name;
        private short _emailTypeID;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
        [DataMember]
        public short EmailTypeID { get => _emailTypeID; set => _emailTypeID = value; }
    }

    [DataContract]
    public class Address
    {
        private long _ID;
        private string _location;
        private long _cityID;
        private short _addressTypeID;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Location { get => _location; set => _location = value; }
        [DataMember]
        public long CityID { get => _cityID; set => _cityID = value; }
        [DataMember]
        public short AddressTypeID { get => _addressTypeID; set => _addressTypeID = value; }
    }
    [DataContract]
    public class PhoneType
    {
        private long _ID;
        private String _name;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
    }
    [DataContract]
    public class EmailType
    {
        private long _ID;
        private String _name;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
    }
    [DataContract]
    public class AddressType
    {
        private long _ID;
        private String _name;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
    }
    [DataContract]
    public class City
    {
        private long _ID;
        private string _name;
        private int _countryID;
        [DataMember]
        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        [DataMember]
        public string Name {  get { return _name; }  set { _name = value; }  }
        [DataMember]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


    }
    [DataContract]
    public class Country
    {
        private int _ID;
        private string _name;
        [DataMember]
        public int ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
    }
    [DataContract]
    public class Religion
    {
        private int _ID;
        private string _name;
        [DataMember]
        public int ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
    }



}

