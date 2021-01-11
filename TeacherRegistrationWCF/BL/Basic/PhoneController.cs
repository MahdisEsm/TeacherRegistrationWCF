using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.Basic;

namespace BL.Basic
{
    public class PhoneController : Base.BaseController<Common.Models.Basic.Phone>
    {
        public override async Task<List<Phone>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            if (ex.Message.Contains("UK_Phone_Number"))
            {
                result.ErrorMessage.Add("امکان ثبت تلفن تکراری وجود ندارد");

            }
            return result;
        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Phone> phoneList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (phoneList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات تماس ثبت نشده است");
                    return result;
                }
                phoneList.ForEach(p => p.IsFinalized = true);
                foreach (var item in phoneList)
                {
                    await Edit(item);
                }
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage.Add(ex.ToString());
                result.Success = false;
                return result;

            }

        }
        public async Task<ActionResult> DeFinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Phone> phoneList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (phoneList == null)
                {
                    result.Success = true;
                    return result;
                }
                phoneList.ForEach(p => p.IsFinalized = false);
                foreach (var item in phoneList)
                {
                    await Edit(item);
                }
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage.Add(ex.ToString());
                result.Success = false;
                return result;

            }

        }
    }
   
}
