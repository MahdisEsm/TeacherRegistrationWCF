using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.Basic;

namespace BL.Basic
{
    public class PersonController : Base.BaseController<Common.Models.Basic.Person>
    {
        public override async Task<List<Person>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            if (ex.Message.Contains("UK_Person_NationalCode"))
            {
                result.ErrorMessage.Add("امکان ثبت کد ملی تکراری وجود ندارد");

            }
            if (ex.Message.Contains("UK_Person_Username"))
            {
                result.ErrorMessage.Add("امکان ثبت نام کاربری تکراری وجود ندارد");

            }
            return result;
        }

        public async Task<List<Person>> GetPersonByUsername(string username)
        {
            return await EntityCollection.Where(w => w.Username == username).ToListAsync();
        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Person> personList = EntityCollection.Where(w => w.ID == PersonID).ToList();
                if (personList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات شخصی ثبت نشده است");
                    return result;
                }
                personList.ForEach(p => p.IsFinalized = true);
                foreach (var item in personList)
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
                List<Person> personList = EntityCollection.Where(w => w.ID == PersonID).ToList();
                if (personList == null)
                {
                    result.Success = true;
                    return result;
                }
                personList.ForEach(p => p.IsFinalized = false);
                foreach (var item in personList)
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
