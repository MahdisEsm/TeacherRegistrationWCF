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
    public class FieldController : Base.BaseController<Common.Models.EDU.Field>
    {
        public override async Task<List<Field>> GetList(long id)
        {

            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
    }
}
