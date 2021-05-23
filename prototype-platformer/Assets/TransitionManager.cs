using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class TransitionManager : BaseManager<TransitionManager>
    {
        [SerializeField] TransitionScreen fadeScreen;

        public void ApplyTransition(string _id)
        {
            fadeScreen.PlayAnimation(_id);
        }
    }
}
