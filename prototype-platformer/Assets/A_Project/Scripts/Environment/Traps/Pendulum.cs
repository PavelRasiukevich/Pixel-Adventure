using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Pendulum : MonoBehaviour
    {
        [SerializeField] HingeJoint2D hinge2d;

        private void Awake()
        {
            hinge2d = GetComponent<HingeJoint2D>();
        }

        private void FixedUpdate()
        {

            if (hinge2d.jointAngle >= hinge2d.limits.max)
            {
                var _motor = hinge2d.motor;
                _motor.motorSpeed = -_motor.motorSpeed;

                hinge2d.motor = _motor;
            }
            else if (hinge2d.jointAngle <= hinge2d.limits.min)
            {
                var _motor = hinge2d.motor;
                _motor.motorSpeed = -_motor.motorSpeed;

                hinge2d.motor = _motor;
            }
        }
    }
}
