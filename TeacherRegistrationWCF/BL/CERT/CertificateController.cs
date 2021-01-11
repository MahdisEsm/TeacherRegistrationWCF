using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.CERT;

namespace BL.CERT
{
    public class CertificateController : Base.BaseController<Common.Models.CERT.Certificate>
    {
        public override async Task<List<Certificate>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Certificate>> GetListByPersonID(long personID)
        {
            return await EntityCollection.Where(w => w.PersonID == personID).ToListAsync();

        }
        public async Task<ActionResult> DeleteByPersonID(long personID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var certificates = await GetListByPersonID(personID);
                foreach (var item in certificates)
                {
                    _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;

                }
                await _context.SaveChangesAsync();
                result.Success = true;
                return result;
            }

            catch (Exception ex)
            {
                result.Success = false;
                return result;
                throw;
            }

        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Certificate> certificateList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (certificateList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات مدارک ثبت نشده است");
                    return result;
                }
                certificateList.ForEach(p => p.IsFinalized = true);
                foreach (var item in certificateList)
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
                List<Certificate> certificateList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (certificateList == null)
                {
                    result.Success = true;
                    return result;
                }
                certificateList.ForEach(p => p.IsFinalized = false);
                foreach (var item in certificateList)
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
