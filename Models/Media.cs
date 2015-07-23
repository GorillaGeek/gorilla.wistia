using System;
using System.Collections.Generic;

namespace Gorilla.Wistia.Models
{

    public class Media
    {
        public int account_id { get; set; }
        public string hashed_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public float progress { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Project project { get; set; }
        public List<Asset> assets { get; set; }
    }
}