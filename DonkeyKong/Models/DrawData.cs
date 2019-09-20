using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKong.Models
{
    public class DrawData
    {
        public List<Ladder> Ladders { get; set; }

        public List<Beam> Beams { get; set; }

        public Mario Mario { get; set; }
    }
}
