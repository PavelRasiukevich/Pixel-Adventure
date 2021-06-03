using UnityEngine;

namespace PixelAdventure
{
    public class SlugPath : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints;
        [SerializeField] float step;
        [SerializeField] float angleTreshold;

        int index;
        Vector2 direction;

        private void Update()
        {
            if (Vector2.Distance(transform.position, waypoints[index].position) > Mathf.Epsilon)
                transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, step * Time.deltaTime);
            else
            {
                if (index >= waypoints.Length - 1)
                    index = 0;
                else
                    index++;

                ChangeMoveDirection();
            }
        }

        private void ChangeMoveDirection()
        {
            direction = waypoints[index].position - transform.position;

            if (Vector2.Angle(direction.normalized, -transform.up) < angleTreshold)
                transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
