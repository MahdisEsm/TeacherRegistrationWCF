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
    public class SematecCourseController : Base.BaseController<Common.Models.TCH.SematecCourse>
    {
        public override async Task<List<SematecCourse>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
    }
}
