using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public interface IAbility
    {
        public void AddAbility(IControllable player);
    }
}
