using System;
using UnityEngine;

namespace Debris
{
    public static class DebrisManager
    {
        public static DebrisScript instance;
        public static void AddDebrisTime(float life, Action<GameObject> method = null, params GameObject[] objects)
        {
            instance.AddDebrisSecs(life, method, objects);
        }
        public static void AddDebrisFrames(int life, Action<GameObject> method = null, params GameObject[] objects)
        {
            instance.AddDebrisFrames(life, method, objects);
        }
    }
}