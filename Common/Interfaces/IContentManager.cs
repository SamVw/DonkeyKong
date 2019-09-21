using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Interfaces
{
    public interface IContentManager
    {
        void LoadTexture(string name);
        void UnLoadTexture(string name);
        Texture2D GetTexture(string name);

        void SetInternalManager(Microsoft.Xna.Framework.Content.ContentManager content);
    }
}