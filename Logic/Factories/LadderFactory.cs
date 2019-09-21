using System.Collections.Generic;
using Common.Entities;
using Microsoft.Xna.Framework;

namespace Logic.Factories
{
    public static class LadderFactory
    {
        public static List<Ladder> InitializeLadders(int width, int height)
        {
            List<Ladder> ladders = new List<Ladder>()
            {
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (width*0.7), height - 150)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (width*0.2), height - 300)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (width*0.8), height - 450)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (width*0.3), height - 600)
                ),
                new Ladder(
                    width: 30,
                    height: 100,
                    color: Color.CornflowerBlue,
                    position: new Point((int) (width*0.7), height - 750)
                )
            };

            return ladders;
        }
    }
}