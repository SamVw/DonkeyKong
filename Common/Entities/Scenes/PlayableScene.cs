using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;

namespace Common.Entities.Scenes
{
    public class PlayableScene : Scene
    {
        public List<Beam> Beams { get; set; }

        public List<Ladder> Ladders { get; set; }

        private Mario mario { get; set; }

        public PlayableScene(Mario mario)
        {
            this.mario = mario;
        }

        public override DrawData GetAllDrawDataForScene()
        {
            List<DrawObject> objects = new List<DrawObject>();

            foreach (var beam in Beams)
            {
                objects.Add(beam.GetDrawData());
            }

            foreach (var ladder in Ladders)
            {
                objects.Add(ladder.GetDrawData());
            }

            objects.Add(mario.GetDrawData());

            return new DrawData() {Objects = objects};
        }
    }
}
