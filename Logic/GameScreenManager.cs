using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using Common.Interfaces;

namespace Logic
{

    public class GameScreenManager : IGameScreenManager
    {
        private GameScreen _gameScreen;

        public int Height => _gameScreen.Height;

        public int Width => _gameScreen.Width;

        public void SetGameScreen(int width, int height)
        {
            _gameScreen = new GameScreen(height, width);
        }
    }
}
