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
    public class AddressTypeController : Base.BaseController<Common.Models.Basic.AddressType>
    {
        public override async Task<List<AddressType>> GetList(long id)
        {
            return await EntityCollection.Where(w => w.ID == id).ToListAsync();
        }

        protected override ActionResult GetErrorMessage(Exception ex, ActionResult result)
        {
            throw new NotImplementedException();
        }
    }
}
