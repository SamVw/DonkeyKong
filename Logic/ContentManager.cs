using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Logic
{
    public class ContentManager : IContentManager
    {
        private Microsoft.Xna.Framework.Content.ContentManager _manager;
        private Dictionary<string, Texture2D> content;

        public ContentManager()
        {
            content = new Dictionary<string, Texture2D>();
        }

        public void LoadTexture(string name)
        {
            content.Add(name, _manager.Load<Texture2D>(name));
        }

        public void UnLoadTexture(string name)
        {
            content.Remove(name);
        }

        public Texture2D GetTexture(string name)
        {
            return content.First(row => row.Key == name).Value;
        }

        public void SetInternalManager(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _manager = content;
        }
    }
}
