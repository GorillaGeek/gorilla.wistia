namespace Gorilla.Wistia.Models
{
    public class Asset
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public long fileSize { get; set; }
        public string contentType { get; set; }
        public string type { get; set; }
    }
}