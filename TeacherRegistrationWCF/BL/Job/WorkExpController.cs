using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.Job;

namespace BL.Job
{
    public class WorkExpController : Base.BaseController<Common.Models.Job.WorkExp>
    {
        public override async Task<List<WorkExp>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
        public async Task<List<WorkExp>> GetListByPersonID(long personID)
        {
            return await EntityCollection.Where(w => w.PersonID == personID).ToListAsync();
           
        }
        public async Task<ActionResult> DeleteByPersonID(long personID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var workExps = await GetListByPersonID(personID);
                foreach (var item in workExps)
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
                List<WorkExp> workExpList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (workExpList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات شغلی ثبت نشده است");
                    return result;
                }
                workExpList.ForEach(p => p.IsFinalized = true);
                foreach (var item in workExpList)
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
                List<WorkExp> workExpList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (workExpList == null)
                {
                    result.Success = true;
                    return result;
                }
                workExpList.ForEach(p => p.IsFinalized = false);
                foreach (var item in workExpList)
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
