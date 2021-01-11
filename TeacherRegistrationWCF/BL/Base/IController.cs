using Common.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base
{
    public interface IController<TEntity>
    {
        Task<List<TEntity>> GetList();
        Task<List<TEntity>> GetList(long id);

        Task<ActionResult> Create(TEntity instance);
        Task<ActionResult> Edit(TEntity instance);
        Task<ActionResult> Delete(TEntity instance);



    }
}
