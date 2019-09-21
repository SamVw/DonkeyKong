using Common.Entities.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Entities
{
    public abstract class Character : GameEntity
    {
        public Point Position;

        public int Width { get; set; }

        public int Height { get; set; }

        public float SpriteScale => (Height + 0.0f) / Sprite.Height;

        public Sprite Sprite { get; set; }

        protected Character()
        {
            Sprite = new Sprite();
        }

        public void SetSprite(string path, int width, int height)
        {
            Sprite.Name = path;
            Sprite.Width = width;
            Sprite.Height = height;
            Width = (int)(Sprite.Width * SpriteScale);
        }

        public void MoveRight(int v)
        {
            Position.X += v;
        }

        public void MoveLeft(int v)
        {
            Position.X -= v;
        }

        public void MoveUp(int v)
        {
            Position.Y -= v;
        }

        public void MoveDown(int v)
        {
            Position.Y += v;
        }
    }
}
