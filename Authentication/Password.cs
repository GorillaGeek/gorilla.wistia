namespace Gorilla.Wistia.Authentication
{
    public class Password : IAuthentication
    {
        private readonly string _password;

        public Password(string password)
        {
            _password = password;
        }

        public string FieldName { get { return "api_password"; } }

        public string Value { get { return _password; } }
    }
}