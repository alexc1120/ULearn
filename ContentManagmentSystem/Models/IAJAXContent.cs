using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContentManagmentSystem.Models
{
    public interface IAJAXContent:IContent
    {
        void Update(StreamWriter streamWriter);
    }
}
