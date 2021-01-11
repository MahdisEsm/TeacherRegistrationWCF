using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base
{
    public class FinalizeRegistration
    {
        private BL.Basic.PersonController _personController;
        private BL.Basic.AddressController _addressController;
        private BL.Basic.EmailController _emailController;
        private BL.Basic.PhoneController _phoneController;
        private BL.CERT.CertificateController _certificateController;
        private BL.EDU.DegreeController _degreeController;
        private BL.Job.WorkExpController _workExpController;
        private BL.TCH.FavoriteCourseController _favoriteCourseController;
        private BL.TCH.TeachingExpController _teachingExpController;
        public FinalizeRegistration()
        {
            _addressController = new Basic.AddressController();
            _certificateController = new CERT.CertificateController();
            _degreeController = new EDU.DegreeController();
            _personController = new Basic.PersonController();
            _emailController = new Basic.EmailController();
            _phoneController = new Basic.PhoneController();
            _workExpController = new Job.WorkExpController();
            _favoriteCourseController = new TCH.FavoriteCourseController();
            _teachingExpController = new TCH.TeachingExpController();
                
        }
        public async Task<List<Common.CustomTypes.ActionResult>> Finalize(long personID)
        {
            List<Common.CustomTypes.ActionResult> results = new List<Common.CustomTypes.ActionResult>();
            
            
            try
            {
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _personController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _personController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _addressController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _addressController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _emailController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _emailController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _phoneController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _phoneController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _degreeController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _degreeController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _workExpController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _workExpController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _teachingExpController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _teachingExpController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _certificateController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _certificateController.FinalizeRegister(personID).Result.ErrorMessage
                });
                results.Add(new Common.CustomTypes.ActionResult()
                {
                    Success = _favoriteCourseController.FinalizeRegister(personID).Result.Success,
                    ErrorMessage = _favoriteCourseController.FinalizeRegister(personID).Result.ErrorMessage
                });

                if (results.Any(a => a.Success == false))
                {
                    await _personController.DeFinalizeRegister(personID);
                    await _addressController.DeFinalizeRegister(personID);
                    await _emailController.DeFinalizeRegister(personID);
                    await _phoneController.DeFinalizeRegister(personID);
                    await _degreeController.DeFinalizeRegister(personID);
                    await _workExpController.DeFinalizeRegister(personID);
                    await _teachingExpController.DeFinalizeRegister(personID);
                    await _certificateController.DeFinalizeRegister(personID);
                    await _favoriteCourseController.DeFinalizeRegister(personID);

                    return results;
                }
                return results;


            }
            catch (Exception ex)
            {

                throw;
            }


        }




    }
}
