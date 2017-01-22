using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ContentManagmentSystem.Models
{
    public class SeasonalContentImplementation: ISeasonalContent
    {
        private readonly IMonthContent monthContent;
        public SeasonalContentImplementation(IMonthContent monthContent) {
            this.monthContent = monthContent;
        }
        public void DetermineContentToDisplay(DateTime dateTime)
        {
            monthContent.Display(null);
            throw new NotImplementedException();
        }       

    }
}