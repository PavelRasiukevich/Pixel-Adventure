using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class ObjectPoolManager : BaseManager<ObjectPoolManager>
    {
        [SerializeField] GameObject bluePrint;
        [SerializeField] List<GameObject> afterImage;
        [SerializeField] int ammount;

        private void Start()
        {
            for (int i = 0; i < ammount; i++)
            {
                CreateObject();
            }
        }

        private void CreateObject()
        {
            var _obj = Instantiate(bluePrint);
            _obj.transform.SetParent(transform);
            _obj.SetActive(false);
            afterImage.Add(_obj);
        }

        public GameObject GetObjectFromPool()
        {
            for (int i = 0; i < afterImage.Count; i++)
            {
                if (!afterImage[i].activeInHierarchy)
                    return afterImage[i];
                else
                    CreateObject();
            }

            return null;
        }
    }
}
