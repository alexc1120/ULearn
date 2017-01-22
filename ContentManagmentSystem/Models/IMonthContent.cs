using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagmentSystem.Models
{
    public interface IMonthContent:IContent
    {
    }
    public class MonthContent : IMonthContent
    {
        public void Display(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }
}
