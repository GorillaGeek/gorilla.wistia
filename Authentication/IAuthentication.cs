namespace Gorilla.Wistia.Authentication
{
    public interface IAuthentication
    {

        string FieldName { get; }
        string Value { get; }

    }
}