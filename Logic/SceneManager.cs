using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Logic
{
    public class SceneManager
    {
        private List<Scene> _scenes { get; set; }

        private Scene _currentScene { get; set; }

        public Scene CurrentScene => _currentScene;

        // Load all scenes on startup of game
        public void LoadScenes()
        {
            throw new NotImplementedException();
        }


        // Load next game scene
        public Scene Next()
        {
            throw new NotImplementedException();
        }

        // Load previous game scene
        public Scene Previous()
        {
            throw new NotImplementedException();
        }
    }
}
