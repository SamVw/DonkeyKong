using System.Collections.Generic;
using DonkeyKong.Models;
using Microsoft.Xna.Framework;

namespace DonkeyKong.Factories
{
    public static class LadderFactory
    {
        public static List<Ladder> InitializeLadders(GameScreen baseScreenSize)
        {
            List<Ladder> ladders = new List<Ladder>()
            {
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (baseScreenSize.Width*0.7), baseScreenSize.Height - 150)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (baseScreenSize.Width*0.2), baseScreenSize.Height - 300)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (baseScreenSize.Width*0.8), baseScreenSize.Height - 450)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (baseScreenSize.Width*0.3), baseScreenSize.Height - 600)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (baseScreenSize.Width*0.7), baseScreenSize.Height - 750)
                )
            };

            return ladders;
        }
    }
}