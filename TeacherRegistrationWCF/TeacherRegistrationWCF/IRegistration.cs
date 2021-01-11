using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRegistrationWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegistration" in both code and config file together.
    [ServiceContract]
    public interface IRegistration
    {
        [OperationContract]
        ActionResult Login(string username, string password);

        [OperationContract]
        long GetPersonID(string username);

        [OperationContract]
        Person GetPersonByID(long id);

        [OperationContract]
        ICollection<Person> GetAllPerson();

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

        //-------------------------person------------------------
        //[OperationContract]
        //Task<ActionResult> SubmitPersonalInfo(Person person, List<Phone> phones, List<Email> emails, List<Address> addresses);
        [OperationContract]
        Person CreatePerson();
        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SavePerson(Person person);
        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> EditPerson(Person person);
        //-----------------------phone-------------------------------
        [OperationContract]
        void SubmitPhones(List<Phone> phones, long personID);
        //[OperationContract]
        //void EditPhonesAsync(List<Phone> phones, long personID);
        //-----------------------email--------------------------------
        [OperationContract]
        void SubmitEmails(List<Email> Emails, long personID);
        //[OperationContract]
        //void EditEmailsAsync(List<Phone> phones, long personID);
        //----------------------address-------------------------------
        [OperationContract]
        void SubmitAddresses(List<Address> Addresses, long personID);
        //--------------------------EducationalExperience---------------------
        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SubmitEducationalExperience(List<Degree> degrees);
        [OperationContract]
        void EditEducationalExperience(List<Degree> degrees);
        [OperationContract]
        List<Degree> GetEducationalExperience(long personID);
        [OperationContract]
        void DeleteByPersonID(long personID);
        [OperationContract]
        ICollection<Grade> GetAllGrade();
        [OperationContract]
        ICollection<Field> GetAllField();
        [OperationContract]
        ICollection<SubField> GetAllSubField(int fieldID);

        //-----------------------------WorkExp------------------------------------------

        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SubmitWorkExperience(List<WorkExp> workExps);
        [OperationContract]
        List<WorkExp> GetWorkExperience(long personID);
        [OperationContract]
        void DeleteWorkExpByPersonID(long personID);
        //-----------------------------TeachingExp------------------------------------------

        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SubmitTeachingExperience(List<TeachingExp> TeachingExps);
        [OperationContract]
        List<TeachingExp> GetTeachingExperience(long personID);
        [OperationContract]
        void DeleteTeachingExpByPersonID(long personID);
        //-----------------------------Certificate------------------------------------------

        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SubmitCertificate(List<Certificate> certificates);
        [OperationContract]
        List<Certificate> GetCertificate(long personID);
        [OperationContract]
        void DeleteCertificateByPersonID(long personID);
        //-----------------------------FavoriteCourse------------------------------------------

        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> SubmitFavoriteCourse(List<FavoriteCourse> favoriteCourses);
        [OperationContract]
        List<FavoriteCourse> GetFavoriteCourse(long personID);
        [OperationContract]
        ICollection<SematecCourse> GetSematecCourse();
        [OperationContract]
        void DeleteFavoriteCourseByPersonID(long personID);

        //-----------------------------Final Registration------------------------------------------
        [OperationContract]
        Task<List<Common.CustomTypes.ActionResult>> FinalRegistration(long personID);
        //-----------------------------------------------------------------------

        [OperationContract]
        ICollection<City> GetAllCity();
        [OperationContract]
        ICollection<Country> GetAllCountry();
        [OperationContract]
        ICollection<Religion> GetAllReligion();

        
    }


    [DataContract]
    public class Person
    {
        private long _ID;
        private string _firstName;
        private string _lastName;
        private string _nationalCode;
        private string _birthDate;
        private byte _gender;
        private string _picFileName;
        private string _picFileContent;
        private string _username;
        private string _password;
        private long _birthPlaceID;
        private int _religionID;
        private bool _maritalStatus;
        private short _childNumber;
        private int _countryID;
        private string _resumeContent;
        private string _resumeFileName;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }

        [DataMember]
        public string FirstName { get => _firstName; set => _firstName = value; }
        [DataMember]
        public string LastName { get => _lastName; set => _lastName = value; }
        [DataMember]
        public string NationalCode { get => _nationalCode; set => _nationalCode = value; }
        [DataMember]
        public string BirthDate { get => _birthDate; set => _birthDate = value; }
        [DataMember]
        public byte Gender { get => _gender; set => _gender = value; }
        [DataMember]
        public string PicFileName { get => _picFileName; set => _picFileName = value; }
        [DataMember]
        public string PicFileContent { get => _picFileContent; set => _picFileContent = value; }
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
        public string ResumeContent { get => _resumeContent; set => _resumeContent = value; }
        [DataMember]
        public string ResumeFileName { get => _resumeFileName; set => _resumeFileName = value; }
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
        public string Name { get { return _name; } set { _name = value; } }
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

    [DataContract]
    public class Certificate
    {

        private long _ID;
        private long _personID;
        private string _name;
        private string _date;
        private string _institude;
        private bool _isAvailable;
        private string _onlineLink;
        private int _countryID;
        private string _certPic;
        private bool _hasPaper;
        [DataMember]
        public long ID { get => _ID; set => _ID = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
        [DataMember]
        public long PersonID { get => _personID; set => _personID = value; }
        [DataMember]
        public string Date { get => _date; set => _date = value; }
        [DataMember]
        public string Institude { get => _institude; set => _institude = value; }
        [DataMember]
        public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }
        [DataMember]
        public string OnlineLink { get => _onlineLink; set => _onlineLink = value; }
        [DataMember]
        public int CountryID { get => _countryID; set => _countryID = value; }
        [DataMember]
        public string CertPic { get => _certPic; set => _certPic = value; }
        [DataMember]
        public bool HasPaper { get => _hasPaper; set => _hasPaper = value; }
    }

    [DataContract]
    public class Degree
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long PersonID { get; set; }
        [DataMember]
        public short GradeID { get; set; }
        [DataMember]
        public int FieldID { get; set; }
        [DataMember]
        public int SubFieldID { get; set; }
        [DataMember]
        public string University { get; set; }
        [DataMember]
        public long CityID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]

        public string ToDate { get; set; }

    }

    [DataContract]
    public class Field 
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }

    }

    [DataContract]
    public class Grade 
    {
        [DataMember]
        public short ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class SubField
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int FieldID { get; set; }
    }

    [DataContract]
    public class University 
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long CityID { get; set; }
        [DataMember]
        public int CountryID { get; set; }

    }


    [DataContract]
    public class WorkExp
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long PersonID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string CompanyPhone { get; set; }
        [DataMember]
        public string Manager { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Duties { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]

        public string ToDate { get; set; }
    }

    [DataContract]
    public class FavoriteCourse
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public long PersonID { get; set; }
        [DataMember]
        public int SematecCourseID { get; set; }

    }

    [DataContract]
    public class SematecCourse 
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class TeachingExp
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long PersonID { get; set; }
        [DataMember]
        public string Institude { get; set; }
        [DataMember]
        public int Hours { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string CourseNames { get; set; }
    }

    [DataContract]
    public class ActionResult
    {
        private bool _success;
        private List<string> _errorMessage;
        public ActionResult()
        {
            _success = false;
            _errorMessage = new List<string>();
                
        }
        [DataMember]
        public bool Success { get => _success; set => _success = value; }
        [DataMember]
        public List<string> ErrorMessage { get => _errorMessage; set => _errorMessage = value; }

    }




}
