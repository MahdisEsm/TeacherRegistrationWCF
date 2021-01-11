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
    public class UniversityController : Base.BaseController<Common.Models.EDU.University>
    {
        public override async Task<List<University>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
    }
}
