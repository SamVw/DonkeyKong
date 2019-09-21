using System.Collections.Generic;

namespace Common.Entities
{
    public class Level
    {
        public List<Ladder> Ladders { get; set; }

        public List<Beam> Beams { get; set; }
    }
}
