using System;
using System.Collections.Generic;

namespace Gorilla.Wistia.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int mediaCount { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string hashedId { get; set; }
        public bool anonymousCanUpload { get; set; }
        public bool anonymousCanDownload { get; set; }
        public bool @public { get; set; }
        public string publicId { get; set; }
        public List<Media> medias { get; set; }
    }
}