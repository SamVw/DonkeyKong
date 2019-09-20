using System.Collections.Generic;
using DonkeyKong.Models;
using Microsoft.Xna.Framework;

namespace DonkeyKong.Factories
{
    public static class BeamFactory
    {
        public static List<Beam> InitializeBeams(GameScreen baseScreenSize)
        {
            List<Beam> beams = new List<Beam>()
            {
                new Beam(
                    width: (int) baseScreenSize.Width,
                    height: 50,
                    color: Color.HotPink,
                    position: new Point(0, baseScreenSize.Height - 50)
                )
            };

            var lastBeamY = baseScreenSize.Height - 50;

            while (lastBeamY >= 350)
            {
                var beamy = lastBeamY - 150;

                var beamx = beams.Count % 2 == 0 ? 100 : 0;
                beams.Add(
                    new Beam(
                        width: (int) (baseScreenSize.Width - 100),
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