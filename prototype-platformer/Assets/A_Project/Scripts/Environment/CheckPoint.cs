using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hintText;
        [SerializeField] TextMeshProUGUI hintText_2;
        [SerializeField] bool isSaved;

        public bool IsSaved { get => isSaved; set => isSaved = value; }

        private void OnTriggerStay2D(Collider2D collision)
        {

            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                if (Input.GetKeyDown(KeyCode.F) && !isSaved)
                {
                    isSaved = true;
                    GameInfo.Instance.UserData.PlayerSpawnPosition = transform.position;
                    GameInfo.Instance.SaveGameProgress();
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null && !isSaved)
                hintText.gameObject.SetActive(true);
            else
                hintText_2.gameObject.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();
            if (_player != null)
            {
                hintText.gameObject.SetActive(false);
                hintText_2.gameObject.SetActive(false);
            }
        }
    }
}
