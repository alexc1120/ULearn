namespace ContentManagmentSystem.Models
{
    public interface IAbstractFactory
    {
        IContent GetIContent();
        IContent GetIAJAXContent();
        ISeasonalContent GetISeasonalContent();
    }
}
