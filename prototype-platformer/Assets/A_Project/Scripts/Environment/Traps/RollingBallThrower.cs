using UnityEngine;

namespace PixelAdventure
{
    public class RollingBallThrower : MonoBehaviour
    {
        [SerializeField] RollingBall prefab;
        [SerializeField] float repeatTime;
        [SerializeField] float startTime;

        private void Awake()
        {
            InvokeRepeating("GenerateBall", startTime, repeatTime);
        }

        void GenerateBall()
        {
            var _ball = Instantiate(prefab);
            _ball.transform.position = transform.position;
        }
    }
}
