using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;
using Common.Models.EDU;

namespace BL.EDU
{
    public class DegreeController : Base.BaseController<Common.Models.EDU.Degree>
    {
        
        public override async Task<List<Degree>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
            
        }
        public async Task<List<Degree>> GetListByPersonID(long personID)
        {
            var degreeList = await EntityCollection.Where(w => w.PersonID == personID).ToListAsync();
            return degreeList;
        }
        public async Task<ActionResult> DeleteByPersonID(long personID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var degrees=await GetListByPersonID(personID);
                foreach (var item in degrees)
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
        
        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
        public async Task<ActionResult> FinalizeRegister(long PersonID)
        {
            ActionResult result = new ActionResult();
            try
            {
                List<Degree> degreeList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (degreeList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات تحصیلی ثبت نشده است");
                    return result;
                }
                degreeList.ForEach(p => p.IsFinalized = true);
                foreach (var item in degreeList)
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
                List<Degree> degreeList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (degreeList == null)
                {
                    result.Success = true;
                    return result;
                }
                degreeList.ForEach(p => p.IsFinalized = false);
                foreach (var item in degreeList)
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
