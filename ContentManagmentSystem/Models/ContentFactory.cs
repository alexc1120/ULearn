using System;

namespace ContentManagmentSystem.Models
{
    public class ContentFactory : IAbstractFactory
    {
        public IContent GetIAJAXContent()
        {
            throw new NotImplementedException();
        }

        public IContent GetIContent()
        {
            throw new NotImplementedException();
        }

        public ISeasonalContent GetISeasonalContent()
        {
            throw new NotImplementedException();
        }
    }
}