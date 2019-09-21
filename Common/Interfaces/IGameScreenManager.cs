using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IGameScreenManager
    {
        int Height { get; }
        int Width { get; }
        void SetGameScreen(int width, int height);
    }
}
