using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyKong.Models;

namespace DonkeyKong.Factories
{
    public static class CharacterFactory
    {
        public static Character Create(string name)
        {
            return (Character)Activator.CreateInstance(Type.GetType($"DonkeyKong.Models.{name}"));
        }
    }
}
