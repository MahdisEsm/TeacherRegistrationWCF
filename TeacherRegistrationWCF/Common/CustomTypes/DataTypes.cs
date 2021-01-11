using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomTypes
{
        public struct ActionResult
        {
            public bool Success { get; set; }
            public List<string> ErrorMessage { get; set; }

            public object ReturnData { get; set; }
        }
    
   
}
