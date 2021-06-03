using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class LoadGameButton : MonoBehaviour
    {
        Button btn;

        private void Awake()
        {
            btn = GetComponent<Button>();

            if (GameInfo.Instance.HasLoad())
            {
                btn.interactable = true;
            }
            else
            {
                btn.interactable = false;
                GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            }
        }
    }
}
