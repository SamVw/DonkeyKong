using System.Collections.Generic;
using Common.Entities;
using Microsoft.Xna.Framework;

namespace Logic.Factories
{
    public static class BeamFactory
    {
        public static List<Beam> InitializeBeams(int width, int height)
        {
            List<Beam> beams = new List<Beam>()
            {
                new Beam(
                    width: (int) width,
                    height: 50,
                    color: Color.HotPink,
                    position: new Point(0, height - 50)
                )
            };

            var lastBeamY = height - 50;

            while (lastBeamY >= 350)
            {
                var beamy = lastBeamY - 150;

                var beamx = beams.Count % 2 == 0 ? 100 : 0;
                beams.Add(
                    new Beam(
                        width: (int) (width - 100),
                        height: 50,
                        color: Color.HotPink,
                        position: new Point(beamx, beamy)
                    )
                );
                lastBeamY = beamy;
            }

            return beams;
        }
    }
}