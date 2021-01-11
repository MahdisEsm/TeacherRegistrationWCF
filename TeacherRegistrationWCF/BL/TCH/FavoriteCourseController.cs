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
    public class FavoriteCourseController : Base.BaseController<Common.Models.TCH.FavoriteCourse>
    {
        public override async Task<List<FavoriteCourse>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {

            if ((ex is InvalidOperationException) && (ex.Source == "EntityFramework") && ex.Message.Contains("Unique-key"))
            {
                result.ErrorMessage.Add("امکان ثبت دوره ی تکراری وجود ندارد");
               
            }
            return result;
        }
        public async Task<List<FavoriteCourse>> GetListByPersonID(long personID)
        {
            return await EntityCollection.Where(w => w.PersonID == personID).ToListAsync();

        }

        public async Task<ActionResult> DeleteByPersonID(long personID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var favoriteCourses = await GetListByPersonID(personID);
                foreach (var item in favoriteCourses)
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
                List<FavoriteCourse> favCourseList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (favCourseList == null)
                {
                    result.Success = false;
                    result.ErrorMessage.Add("اطلاعات دوره های مورد علاقه ثبت نشده است");
                    return result;
                }
                favCourseList.ForEach(p => p.IsFinalized = true);
                foreach (var item in favCourseList)
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
                List<FavoriteCourse> favCourseList = EntityCollection.Where(w => w.PersonID == PersonID).ToList();
                if (favCourseList == null)
                {
                    result.Success = true;
                    return result;
                }
                favCourseList.ForEach(p => p.IsFinalized = false);
                foreach (var item in favCourseList)
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
