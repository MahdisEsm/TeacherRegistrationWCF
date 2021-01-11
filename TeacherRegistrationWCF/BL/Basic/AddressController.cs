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
    public class AddressController : Base.BaseController<Common.Models.Basic.Address>
    {
        public override async Task<List<Address>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Address> addressList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (addressList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات آدرس ثبت نشده است");
                    return result;
                }
                addressList.ForEach(p => p.IsFinalized = true);
                foreach (var item in addressList)
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
                List<Address> addressList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (addressList == null)
                {
                    result.Success = true;
                    return result;
                }
                addressList.ForEach(p => p.IsFinalized = false);
                foreach (var item in addressList)
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
