﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagmentSystem.Models
{

    public interface ISeasonalContent
    {
        void DetermineContentToDisplay(DateTime dateTime);
    }
}