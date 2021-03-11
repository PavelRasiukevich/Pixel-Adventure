using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public static class EventBrocker
    {
        public static Action<Transform> OnPlayerEnable;

        public static void CallOnPlayerEnable(Transform transform)
        {
            OnPlayerEnable?.Invoke(transform);
        }
    }
}
