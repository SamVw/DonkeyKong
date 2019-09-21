using System;
using Common.Interfaces;
using Logic;

namespace DonkeyKong
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var contentManager = new ContentManager();
            var gameScreenManager = new GameScreenManager();
            var donkeyKongGame = new DonkeyKongGame(contentManager, gameScreenManager);
            using (var game = new MainGame(donkeyKongGame, contentManager, gameScreenManager))
                game.Run();
        }
    }
#endif
}
