using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Basic;

namespace TeacherRegistrationWCF
{
    public class RegistrationService : IRegistration
    {
        public BL.Basic.PersonController _personController;
        public BL.Basic.PhoneController _phoneController;
        public BL.Basic.EmailController _emailController;
        public BL.Basic.AddressController _addressController;
        public BL.Basic.PhoneTypeController _phoneTypeController;
        public BL.Basic.EmailTypeController _emailTypeController;
        public BL.Basic.AddressTypeController _addressTypeController;
        public BL.Basic.CityController _cityController;
        public BL.Basic.CountryController _countryController;
        public BL.Basic.ReligionController _religionController;
        public Common.Models.Basic.Person _personInstance;
        public Common.Models.Basic.Phone _phoneInstance;
        public Common.Models.Basic.Email _emailInstance;
        public Common.Models.Basic.Address _addressInstance;
        public List<Phone> _phones;

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

        }

        private async void SubmitPhonesAsync(Phone phone, long personID)
        {
            _phoneInstance = new Common.Models.Basic.Phone();
            _phoneInstance.Number = phone.Number;
            _phoneInstance.PhoneTypeID = phone.PhoneTypeID;
            _phoneInstance.PersonID = personID;
            await _phoneController.Create(_phoneInstance);

        }
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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.Wrapped)]
        public async void SubmitPersonalInfoAsync(Person person, List<Phone> phones, List<Email> emails, List<Address> addresses)

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
            _personInstance.ResumeContent = person.ResumeContent;
            _personInstance.Username = person.Username;
            _personInstance.PicFileName = person.PicFileName;
            _personInstance.PicFileContent = person.PicFileContent;
            try
            {
                await _personController.Create(_personInstance);


                await _personController.GetList(_personInstance.ID);

                foreach (var item in phones)
                {
                    SubmitPhonesAsync(item, _personInstance.ID);
                }
                foreach (var item in addresses)
                {
                    SubmitAddressAsync(item, _personInstance.ID);
                }

                foreach (var item in emails)
                {
                    SubmitEmailAsync(item, _personInstance.ID);
                }
            }
            catch (Exception)
            {

                throw;
            }

           
        }
        [WebGet(ResponseFormat =WebMessageFormat.Json)]
        public ICollection<Person> GetAllPerson()
        {
            List<Person> personList = new List<Person>();
            _personController.GetList().Result.ForEach(a=>personList.Add(new Person()
            {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName=a.LastName,
                BirthDate=a.BirthDate,
                BirthPlaceID=a.BirthPlaceID,
                ChildNumber=a.ChildNumber,
                CountryID=a.CountryID,
                Gender=a.Gender,
                MaritalStatus=a.MaritalStatus,
                NationalCode=a.NationalCode,
                Password=a.Password,
                PicFileContent=a.PicFileContent,
                PicFileName=a.PicFileName,
                ReligionID=a.ReligionID,
                ResumeContent=a.ResumeContent,
                Username=a.Username

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
                Name=a.Name

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
                CountryID=a.CountryID

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
        [WebGet(ResponseFormat = WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json)]
        public bool Login(string username, string password)
        {

           if(_personController.GetPersonByUsername(username).Result.FirstOrDefault() is null)
            {
                throw new FaultException("نام کاربری صحیح نمی باشد");
            }
            else if(_personController.GetPersonByUsername(username).Result.FirstOrDefault().Password!= password)
            {
                throw new FaultException("رمز عبور صحیح نیست");
            }
            else if(_personController.GetPersonByUsername(username).Result.FirstOrDefault().Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
