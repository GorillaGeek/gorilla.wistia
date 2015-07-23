namespace Gorilla.Wistia.Modules.Stats
{
    public class Stats
    {
        private readonly Client _client;
        public Stats(Client client)
        {
            _client = client;
        }

        public Media Media => new Media(_client);
        public Project Project => new Project(_client);
        public Account Account => new Account(_client);
    }
}