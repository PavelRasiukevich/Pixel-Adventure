using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class SavePoint : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hintText;
        [SerializeField] bool isSaved;
        [SerializeField] int id;

        public bool IsSaved { get => isSaved; set => isSaved = value; }
        public int Id { get => id; }

        private void OnTriggerStay2D(Collider2D collision)
        {

            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                if (Input.GetKeyDown(KeyCode.F) && !isSaved)
                {
                    isSaved = true;
                    hintText.text = $"Saved";
                    GameInfo.Instance.SetSavePointId(id);
                    GameInfo.Instance.SaveGameProgress();
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                hintText.gameObject.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                hintText.gameObject.SetActive(false);
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }
    }
}
