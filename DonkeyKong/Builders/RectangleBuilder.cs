using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = DonkeyKong.Models.Rectangle;

namespace DonkeyKong.Builders
{
    public class RectangleBuilder
    {
        private readonly GraphicsDeviceManager _graphics;

        public RectangleBuilder(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;

        }

        public Texture2D BuildTexture(Rectangle rec)
        {
            var recTexture2D = new Texture2D(_graphics.GraphicsDevice, rec.Width, rec.Height);

            Color[] data = new Color[rec.Width * rec.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = rec.Color;
            recTexture2D.SetData(data);

            return recTexture2D;
        }
    }
}