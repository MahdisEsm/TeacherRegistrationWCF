using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;

namespace TeacherRegistrationWCF
{

    public class RegistrationService : IRegistration
    {
        private BL.Basic.PhoneController _phoneController;
        private BL.Basic.EmailController _emailController;
        private BL.Basic.AddressController _addressController;
        private BL.Basic.PhoneTypeController _phoneTypeController;
        private BL.Basic.EmailTypeController _emailTypeController;
        private BL.Basic.AddressTypeController _addressTypeController;
        private BL.Basic.CityController _cityController;
        private BL.Basic.CountryController _countryController;
        private BL.Basic.ReligionController _religionController;
        private BL.EDU.DegreeController _degreeController;
        private BL.Job.WorkExpController _workExpController;
        private BL.TCH.TeachingExpController _teachingExpController;
        private BL.CERT.CertificateController _certificateController;
        private BL.TCH.FavoriteCourseController _favoriteCourseController;
        private BL.TCH.SematecCourseController _sematecCourseController;
        private BL.EDU.GradeController _gradeController;
        private BL.Basic.PersonController _personController;
        private BL.EDU.FieldController _fieldController;
        private BL.EDU.SubFieldController _subFieldController;
        private Common.Models.Basic.Person _personInstance;
        private Common.Models.Basic.Email _emailInstance;
        private Common.Models.Basic.Address _addressInstance;
        private BL.Base.FinalizeRegistration _finalizeRegistration;

        public RegistrationService()
        {
            _personController = new BL.Basic.PersonController();
            _personInstance = new Common.Models.Basic.Person();
            _phoneController = new BL.Basic.PhoneController();
            _emailController = new BL.Basic.EmailController();
            _addressController = new BL.Basic.AddressController();
            _addressTypeController = new BL.Basic.AddressTypeController();
            _phoneTypeController = new BL.Basic.PhoneTypeController();
            _emailTypeController = new BL.Basic.EmailTypeController();
            _cityController = new BL.Basic.CityController();
            _countryController = new BL.Basic.CountryController();
            _religionController = new BL.Basic.ReligionController();
            _degreeController = new BL.EDU.DegreeController();
            _workExpController = new BL.Job.WorkExpController();
            _teachingExpController = new BL.TCH.TeachingExpController();
            _certificateController = new BL.CERT.CertificateController();
            _favoriteCourseController = new BL.TCH.FavoriteCourseController();
            _sematecCourseController = new BL.TCH.SematecCourseController();
            _finalizeRegistration = new BL.Base.FinalizeRegistration();
            
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void SubmitPhones(List<Phone> phones, long personID)
        {
            if (phones == null)
            {
                return;
            }
            List<Common.Models.Basic.Phone> commanPhones = new List<Common.Models.Basic.Phone>();
            phones.ForEach(f => commanPhones.Add(new Common.Models.Basic.Phone()
            {
                Number = f.Number,
                PhoneTypeID = f.PhoneTypeID,
                PersonID = personID,
            }));
            commanPhones.ForEach(async f => await _phoneController.Create(f));

        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void SubmitEmails(List<Email> Emails, long personID)
        {
            if (Emails == null)
            {
                return;
            }
            List<Common.Models.Basic.Email> commanEmails = new List<Common.Models.Basic.Email>();
            Emails.ForEach(f => commanEmails.Add(new Common.Models.Basic.Email()
            {
                Name = f.Name,
                EmailTypeID = f.EmailTypeID,
                PersonID = personID
            }));
            commanEmails.ForEach(async f => await _emailController.Create(f));
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void SubmitAddresses(List<Address> Addresses, long personID)
        {
            if (Addresses == null)
            {
                return;
            }
            List<Common.Models.Basic.Address> commanAddresses = new List<Common.Models.Basic.Address>();
            Addresses.ForEach(f => commanAddresses.Add(new Common.Models.Basic.Address()
            {
                AddressTypeID = f.AddressTypeID,
                CityID = f.CityID,
                Location = f.Location,
                PersonID = personID
            }));
            commanAddresses.ForEach(async f => await _addressController.Create(f));
        }
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //public async void EditPhonesAsync(Phone phone, long personID)
        //{
        //    _phoneInstance = new Common.Models.Basic.Phone();
        //    _phoneInstance.Number = phone.Number;
        //    _phoneInstance.PhoneTypeID = phone.PhoneTypeID;
        //    _phoneInstance.PersonID = personID;
        //    await _phoneController.Edit(_phoneInstance);

        //}
        private async void SubmitAddressAsync(Address address, long personID)
        {
            _addressInstance = new Common.Models.Basic.Address();
            _addressInstance.AddressTypeID = address.AddressTypeID;
            _addressInstance.Location = address.Location;
            _addressInstance.CityID = address.CityID;
            _addressInstance.PersonID = personID;
            await _addressController.Create(_addressInstance);

        }
        private async void SubmitEmailAsync(Email email, long personID)
        {
            _emailInstance = new Common.Models.Basic.Email();
            _emailInstance.EmailTypeID = email.EmailTypeID;
            _emailInstance.Name = email.Name;
            _emailInstance.PersonID = personID;
            await _emailController.Create(_emailInstance);

        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Person CreatePerson()
        {
            Person person = new Person();
            return person;
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SavePerson(Person person)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            try
            {
                _personInstance.FirstName = person.FirstName;
                _personInstance.LastName = person.LastName;
                _personInstance.BirthDate = person.BirthDate;
                _personInstance.BirthPlaceID = person.BirthPlaceID;
                _personInstance.ChildNumber = person.ChildNumber;
                _personInstance.CountryID = person.CountryID;
                _personInstance.Gender = person.Gender;
                _personInstance.LastLoginDate = DateTime.Today;
                _personInstance.MaritalStatus = person.MaritalStatus;
                _personInstance.NationalCode = person.NationalCode;
                _personInstance.Password = person.Password;
                _personInstance.ReligionID = person.ReligionID;
                _personInstance.ResumeContent = Encoding.ASCII.GetBytes(person.ResumeContent ?? "");
                _personInstance.ResumeFileName = person.ResumeFileName;
                _personInstance.Username = person.Username;
                _personInstance.PicFileName = person.PicFileName;
                _personInstance.PicFileContent = Encoding.ASCII.GetBytes(person.PicFileContent ?? "");


                actionResults.Add(await _personController.Create(_personInstance));
                return actionResults;
                //result.Success = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //result.ErrorMessage.Add(ex.Message);
            }

            //return result;

        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> EditPerson(Person person)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            try
            {
                _personInstance.ID = person.ID;
                _personInstance.FirstName = person.FirstName;
                _personInstance.LastName = person.LastName;
                _personInstance.BirthDate = person.BirthDate;
                _personInstance.BirthPlaceID = person.BirthPlaceID;
                _personInstance.ChildNumber = person.ChildNumber;
                _personInstance.CountryID = person.CountryID;
                _personInstance.Gender = person.Gender;
                _personInstance.LastLoginDate = DateTime.Today;
                _personInstance.MaritalStatus = person.MaritalStatus;
                _personInstance.NationalCode = person.NationalCode;
                _personInstance.Password = person.Password;
                _personInstance.ReligionID = person.ReligionID;
                _personInstance.ResumeContent = Encoding.ASCII.GetBytes(person.ResumeContent ?? "");
                _personInstance.ResumeFileName = person.ResumeFileName;
                _personInstance.Username = person.Username;
                _personInstance.PicFileName = person.PicFileName;
                _personInstance.PicFileContent = Encoding.ASCII.GetBytes(person.PicFileContent ?? "");


               actionResults.Add(await _personController.Edit(_personInstance));
               return actionResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //public async Task<ActionResult> SubmitPersonalInfo(Person person, List<Phone> phones, List<Email> emails, List<Address> addresses)

        //{
        //    ActionResult result = new ActionResult();
        //    try
        //    {
        //        _personInstance.FirstName = person.FirstName;
        //        _personInstance.LastName = person.LastName;
        //        _personInstance.BirthDate = person.BirthDate;
        //        _personInstance.BirthPlaceID = person.BirthPlaceID;
        //        _personInstance.ChildNumber = person.ChildNumber;
        //        _personInstance.CountryID = person.CountryID;
        //        _personInstance.Gender = person.Gender;
        //        _personInstance.LastLoginDate = DateTime.Today;
        //        _personInstance.MaritalStatus = person.MaritalStatus;
        //        _personInstance.NationalCode = person.NationalCode;
        //        _personInstance.Password = person.Password;
        //        _personInstance.ReligionID = person.ReligionID;
        //        _personInstance.ResumeContent = Encoding.ASCII.GetBytes(person.ResumeContent ?? "");
        //        _personInstance.ResumeFileName = person.ResumeFileName;
        //        _personInstance.Username = person.Username;
        //        _personInstance.PicFileName = person.PicFileName;
        //        _personInstance.PicFileContent = Encoding.ASCII.GetBytes(person.PicFileContent ?? "");

        //        await _personController.Create(_personInstance);


        //        await _personController.GetList(_personInstance.ID);

        //        //foreach (var item in phones)
        //        //{
        //        //    SubmitPhonesAsync(item, _personInstance.ID);
        //        //}
        //        //foreach (var item in addresses)
        //        //{
        //        //    SubmitAddressAsync(item, _personInstance.ID);
        //        //}

        //        //foreach (var item in emails)
        //        //{
        //        //    SubmitEmailAsync(item, _personInstance.ID);
        //        //}
        //        result.Success = true;
        //    }
        //    catch (Exception ex)
        //    {

        //        result.ErrorMessage.Add(ex.Message);
        //    }

        //    return result;


        //}
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Person> GetAllPerson()
        {
            List<Person> personList = new List<Person>();
            _personController.GetList().Result.ForEach(a => personList.Add(new Person()
            {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate,
                BirthPlaceID = a.BirthPlaceID,
                ChildNumber = a.ChildNumber,
                CountryID = a.CountryID,
                Gender = a.Gender,
                MaritalStatus = a.MaritalStatus,
                NationalCode = a.NationalCode,
                Password = a.Password,
                PicFileContent = a.PicFileContent is null ? "" : Encoding.ASCII.GetString(a.PicFileContent),
                PicFileName = a.PicFileName,
                ReligionID = a.ReligionID,
                ResumeContent = a.ResumeContent is null ? "" : Encoding.ASCII.GetString(a.ResumeContent),
                ResumeFileName = a.ResumeFileName,
                Username = a.Username

            }));

            return personList;
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<EmailType> GetAllEmailType()
        {
            List<EmailType> emailTypeList = new List<EmailType>();
            _emailTypeController.GetList().Result.ForEach(a => emailTypeList.Add(new EmailType()
            {
                ID = a.ID,
                Name = a.Name

            }));

            return emailTypeList;

        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<PhoneType> GetAllPhoneType()
        {
            List<PhoneType> phoneTypeList = new List<PhoneType>();
            _phoneTypeController.GetList().Result.ForEach(a => phoneTypeList.Add(new PhoneType()
            {
                ID = a.ID,
                Name = a.Name

            }));

            return phoneTypeList;

        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<AddressType> GetAllAddressType()
        {
            List<AddressType> addressTypeList = new List<AddressType>();
            _addressTypeController.GetList().Result.ForEach(a => addressTypeList.Add(new AddressType()
            {
                ID = a.ID,
                Name = a.Name

            }));

            return addressTypeList;
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Phone> GetAllPhone()
        {
            throw new NotImplementedException();
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Email> GetAllEmail()
        {
            throw new NotImplementedException();
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Address> GetAllAddress()
        {
            throw new NotImplementedException();
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<City> GetAllCity()
        {
            List<City> cityList = new List<City>();
            _cityController.GetList().Result.ForEach(a => cityList.Add(new City()
            {
                ID = a.ID,
                Name = a.Name,
                CountryID = a.CountryID

            }));

            return cityList;

        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Country> GetAllCountry()
        {
            List<Country> CountryList = new List<Country>();
            _countryController.GetList().Result.ForEach(a => CountryList.Add(new Country()
            {
                ID = a.ID,
                Name = a.Name

            }));

            return CountryList;
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Religion> GetAllReligion()
        {
            List<Religion> religionList = new List<Religion>();
            _religionController.GetList().Result.ForEach(a => religionList.Add(new Religion()
            {
                ID = a.ID,
                Name = a.Name

            }));

            return religionList;
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public ActionResult Login(string username, string password)
        {
            ActionResult result = new ActionResult();

            try
            {
                if (_personController.GetPersonByUsername(username).Result.FirstOrDefault() is null)
                {
                    result.ErrorMessage.Add("نام کاربری صحیح نمی باشد");
                }
                else if (_personController.GetPersonByUsername(username).Result.FirstOrDefault().Password != password)
                {
                    result.ErrorMessage.Add("رمز عبور صحیح نیست");
                }
                else if (_personController.GetPersonByUsername(username).Result.FirstOrDefault().Password == password)
                {
                    result.Success = true;
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage.Add(ex.Message);
            }

            return result;
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public long GetPersonID(string username)
        {
            return _personController.GetPersonByUsername(username).Result.Select(s => s.ID).FirstOrDefault();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Person GetPersonByID(long id)
        {
            return _personController.GetList(id).Result.Select(a => new Person()
            {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate,
                BirthPlaceID = a.BirthPlaceID,
                ChildNumber = a.ChildNumber,
                CountryID = a.CountryID,
                Gender = a.Gender,
                MaritalStatus = a.MaritalStatus,
                NationalCode = a.NationalCode,
                Password = a.Password,
                PicFileContent = a.PicFileContent is null ? "" : Encoding.ASCII.GetString(a.PicFileContent),
                PicFileName = a.PicFileName,
                ReligionID = a.ReligionID,
                ResumeContent = a.ResumeContent is null ? "" : Encoding.ASCII.GetString(a.ResumeContent),
                ResumeFileName = a.ResumeFileName,
                Username = a.Username
            }).FirstOrDefault();

        }

        //----------------------------------EducationalExperience-------------------------------------------------------


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SubmitEducationalExperience(List<Degree> degrees)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            _degreeController = new BL.EDU.DegreeController();
            List<Common.Models.EDU.Degree> degreeList = new List<Common.Models.EDU.Degree>();
            degrees.ForEach(d => degreeList.Add(new Common.Models.EDU.Degree()
            {
                PersonID = d.PersonID,
                FieldID = d.FieldID,
                SubFieldID = d.SubFieldID,
                CityID = d.CityID,
                CountryID = d.CountryID,
                GradeID = d.GradeID,
                University = d.University,
                FromDate = d.FromDate,
                ToDate = d.ToDate
            }));
            foreach (var item in degreeList)
            {
               actionResults.Add( await _degreeController.Create(item));
            }
            //degreeList.ForEach(async d => await _degreeController.Create(d));
            return actionResults;
        }
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void EditEducationalExperience(List<Degree> degrees)
        {
            throw new NotImplementedException();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<Degree> GetEducationalExperience(long personID)
        {
            _degreeController = new BL.EDU.DegreeController();
            var degreeList = _degreeController.GetListByPersonID(personID).Result.Select(s => new Degree()
            {
                ID = s.ID,
                PersonID = s.PersonID,
                FieldID = s.FieldID,
                SubFieldID = s.SubFieldID,
                CityID = s.CityID,
                CountryID = s.CountryID,
                GradeID = s.GradeID,
                University = s.University,
                FromDate = s.FromDate,
                ToDate = s.ToDate
            }).ToList();
            return degreeList;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Grade> GetAllGrade()
        {
            _gradeController = new BL.EDU.GradeController();
            return _gradeController.GetList().Result.Select(s => new Grade()
            {
                ID = s.ID,
                Name = s.Name
            }).ToList();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Field> GetAllField()
        {
            _fieldController = new BL.EDU.FieldController();
            return _fieldController.GetList().Result.Select(s => new Field()
            {
                ID = s.ID,
                Name = s.Name
            }).ToList();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<SubField> GetAllSubField(int fieldID)
        {
            _subFieldController = new BL.EDU.SubFieldController();
            return _subFieldController.GetList().Result.Where(w => w.FieldID == fieldID)
                .Select(s => new SubField()
                {
                    ID = s.ID,
                    FieldID = s.FieldID,
                    Name = s.Name
                }).ToList();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async void DeleteByPersonID(long personID)
        {
            _degreeController = new BL.EDU.DegreeController();
            await _degreeController.DeleteByPersonID(personID);
        }
        //---------------------------------------------WorkExperience-------------------------------------------------------
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SubmitWorkExperience(List<WorkExp> workExps)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            List<Common.Models.Job.WorkExp> workExpList = new List<Common.Models.Job.WorkExp>();
            workExps.ForEach(d => workExpList.Add(new Common.Models.Job.WorkExp()
            {
                CompanyName = d.CompanyName,
                Duties = d.Duties,
                PersonID = d.PersonID,
                Manager = d.Manager,
                FromDate = d.FromDate,
                ToDate = d.ToDate,
                Position = d.Position,
                CompanyAddress = d.CompanyAddress,
                CompanyPhone = d.CompanyPhone
            }));
            foreach (var item in workExpList)
            {
              actionResults.Add(await _workExpController.Create(item));
            }
            return actionResults;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<WorkExp> GetWorkExperience(long personID)
        {
            var WorkExpList = _workExpController.GetListByPersonID(personID).Result.Select(s => new WorkExp()
            {
                ID = s.ID,
                PersonID = s.PersonID,
                CompanyName = s.CompanyName,
                CompanyAddress = s.CompanyAddress,
                CompanyPhone = s.CompanyPhone,
                Manager = s.Manager,
                Position = s.Position,
                Duties = s.Duties,
                FromDate = s.FromDate,
                ToDate = s.ToDate

            }).ToList();
            return WorkExpList;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async void DeleteWorkExpByPersonID(long personID)
        {
            await _workExpController.DeleteByPersonID(personID);
        }
        //-----------------------------------------------TeachingExperience-----------------------------------------------------
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SubmitTeachingExperience(List<TeachingExp> TeachingExps)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            List<Common.Models.TCH.TeachingExp> TeachingExpList = new List<Common.Models.TCH.TeachingExp>();
            TeachingExps.ForEach(d => TeachingExpList.Add(new Common.Models.TCH.TeachingExp()
            {
                PersonID = d.PersonID,
                Institude = d.Institude,
                Hours = d.Hours,
                CourseNames = d.CourseNames,
                FromDate = d.FromDate,
                ToDate = d.ToDate
            }));
            foreach (var item in TeachingExpList)
            {
                actionResults.Add( await _teachingExpController.Create(item));
            }
            return actionResults;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<TeachingExp> GetTeachingExperience(long personID)
        {
            var TeachingExp = _teachingExpController.GetListByPersonID(personID).Result.Select(s => new TeachingExp()
            {
                ID = s.ID,
                PersonID = s.PersonID,
                Institude = s.Institude,
                CourseNames = s.CourseNames,
                Hours = s.Hours,
                FromDate = s.FromDate,
                ToDate = s.ToDate

            }).ToList();
            return TeachingExp;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async void DeleteTeachingExpByPersonID(long personID)
        {
            await _teachingExpController.DeleteByPersonID(personID);
        }


        //---------------------------------------------Certificate------------------------------------------
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SubmitCertificate(List<Certificate> certificates)
        {
            List<Common.CustomTypes.ActionResult> actionResults = new List<Common.CustomTypes.ActionResult>();
            List<Common.Models.CERT.Certificate> certificateList = new List<Common.Models.CERT.Certificate>();
            certificates.ForEach(d => certificateList.Add(new Common.Models.CERT.Certificate()
            {
                PersonID = d.PersonID,
                Institude = d.Institude,
                CountryID=d.CountryID,
                CertPic= Encoding.ASCII.GetBytes(d.CertPic ?? " "),
                Date=d.Date,
                Name=d.Name,
                HasPaper=d.HasPaper,
                IsAvailable=d.IsAvailable,
                OnlineLink=d.OnlineLink

        }));
            foreach (var item in certificateList)
            {
                actionResults.Add( await _certificateController.Create(item));
            }
            return actionResults;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<Certificate> GetCertificate(long personID)
        {
            var certificate = _certificateController.GetListByPersonID(personID).Result.Select(s => new Certificate()
            {
                ID=s.ID,
                PersonID = s.PersonID,
                Institude = s.Institude,
                CountryID = s.CountryID,
                CertPic = s.CertPic is null ? "" : Encoding.ASCII.GetString(s.CertPic),
                Date = s.Date,
                Name =s.Name,
                HasPaper = s.HasPaper,
                IsAvailable = s.IsAvailable,
                OnlineLink = s.OnlineLink

            }).ToList();
            return certificate;
            
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async void DeleteCertificateByPersonID(long personID)
        {
            await _certificateController.DeleteByPersonID(personID);
        }


        //---------------------------------------------FavoriteCourse------------------------------------------
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> SubmitFavoriteCourse(List<FavoriteCourse> favoriteCourses)
        {
            List<Common.CustomTypes.ActionResult> results = new List<Common.CustomTypes.ActionResult>();
            List<Common.Models.TCH.FavoriteCourse> favoriteCourseList = new List<Common.Models.TCH.FavoriteCourse>();
            favoriteCourses.ForEach(d => favoriteCourseList.Add(new Common.Models.TCH.FavoriteCourse()
            {
               PersonID=d.PersonID,
               SematecCourseID=d.SematecCourseID
               
            }));
            foreach (var item in favoriteCourseList)
            {
                results.Add(await _favoriteCourseController.Create(item));
            }
            return results;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<FavoriteCourse> GetFavoriteCourse(long personID)
        {
            var favoriteCourse = _favoriteCourseController.GetListByPersonID(personID).Result.Select(s => new FavoriteCourse()
            {
                PersonID=s.PersonID,
                SematecCourseID=s.SematecCourseID

            }).ToList();
            return favoriteCourse;
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public ICollection<SematecCourse> GetSematecCourse()
        {
            return _sematecCourseController.GetList().Result.Select(s => new SematecCourse()
            {
                ID=s.ID,
                Name = s.Name

            }).ToList();
        }
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async void DeleteFavoriteCourseByPersonID(long personID)
        {
            await _favoriteCourseController.DeleteByPersonID(personID);
        }


        //-------------------------------------Finalize--------------------------------
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.Wrapped)]
        public async Task<List<Common.CustomTypes.ActionResult>> FinalRegistration(long personID)
        {
            Task < List < Common.CustomTypes.ActionResult >> results =  _finalizeRegistration.Finalize(personID);
            return await results;
        }
    }
}
