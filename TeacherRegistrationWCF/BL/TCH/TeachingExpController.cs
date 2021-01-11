using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.TCH;

namespace BL.TCH
{
    public class TeachingExpController : Base.BaseController<Common.Models.TCH.TeachingExp>
    {
        public override async Task<List<TeachingExp>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
        public async Task<List<TeachingExp>> GetListByPersonID(long personID)
        {
            return await EntityCollection.Where(w => w.PersonID == personID).ToListAsync();

        }

        public async Task<ActionResult> DeleteByPersonID(long personID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var TeachingExps = await GetListByPersonID(personID);
                foreach (var item in TeachingExps)
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
                List<TeachingExp> teachingExpList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (teachingExpList == null)
                {
                    result.Success = true;
                    return result;
                }
                teachingExpList.ForEach(p => p.IsFinalized = true);
                foreach (var item in teachingExpList)
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
                List<TeachingExp> teachingExpList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (teachingExpList == null)
                {
                    result.Success = true;
                    return result;
                }
                teachingExpList.ForEach(p => p.IsFinalized = false);
                foreach (var item in teachingExpList)
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
