using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;

namespace Common.Entities
{
    public abstract class Scene
    {
        public abstract DrawData GetAllDrawDataForScene();
    }
}
