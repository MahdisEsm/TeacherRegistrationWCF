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
    public class EmailController : Base.BaseController<Common.Models.Basic.Email>
    {
        public override async Task<List<Email>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            if (ex.Message.Contains("UK_Email_Name"))
            {
                result.ErrorMessage.Add("امکان ثبت ایمیل تکراری وجود ندارد");

            }
            return result;
        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Email> emailList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (emailList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات ایمیل ثبت نشده است");
                    return result;
                }
                emailList.ForEach(p => p.IsFinalized = true);
                foreach (var item in emailList)
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
                List<Email> emailList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (emailList == null)
                {
                    result.Success = true;
                    return result;
                }
                emailList.ForEach(p => p.IsFinalized = false);
                foreach (var item in emailList)
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
