using System.Collections.Generic;

namespace Gorilla.Wistia.Models.Stats
{
    public class Media
    {
        public int load_count { get; set; }
        public int play_count { get; set; }
        public float play_rate { get; set; }
        public float hours_watched { get; set; }
        public float engagement { get; set; }
        public int visitors { get; set; }
        public List<Action> actions { get; set; }
    }
}