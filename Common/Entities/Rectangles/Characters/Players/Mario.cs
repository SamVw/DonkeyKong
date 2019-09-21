using Common.Dtos;
using Microsoft.Xna.Framework;

namespace Common.Entities
{
    public class Mario : Character
    {
        public float X => Position.X;
        public float Y => Position.Y;

        public Mario()
        {
            
        }

        public void SetPosition(Point position)
        {
            Position = position;
        }

        public void SetDimensions()
        {
            Height = 50;
        }

        public override DrawObject GetDrawData()
        {
            throw new System.NotImplementedException();
        }
    }
}
