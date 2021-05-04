using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelAdventure
{
    public class CameraTransition : MonoBehaviour
    {
        List<CameraSideTrigger> sideColliders;

        private void Awake()
        {
            sideColliders = GetComponentsInChildren<CameraSideTrigger>().ToList();
        }

        private void OnEnable()
        {
            foreach (var side in sideColliders)
            {
                side.SideTriggered += OnSideTriggerHandler;
            }
        }

        private void OnSideTriggerHandler(string _name)
        {

            if (_name.Equals(CameraTriggers.Right_Height.ToString()))
                transform.position = new Vector3(transform.position.x + Values.CAMERA_OFFSET_X,
                    transform.position.y, transform.position.z);
            else if (_name.Equals(CameraTriggers.Left_Height.ToString()))
                transform.position = new Vector3(transform.position.x + -Values.CAMERA_OFFSET_X,
                    transform.position.y, transform.position.z);
            else if (_name.Equals(CameraTriggers.Bottom_Lenght.ToString()))
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + -Values.CAMERA_OFFSET_Y, transform.position.z);
            else if (_name.Equals(CameraTriggers.Up_Lenght.ToString()))
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + Values.CAMERA_OFFSET_Y, transform.position.z);


        }
    }
}
