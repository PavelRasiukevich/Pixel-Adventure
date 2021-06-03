using UnityEngine;

namespace PixelAdventure
{
    public class SawPath : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints;
        [SerializeField] float step;
        [SerializeField] int index;

        private void Update()
        {

            if (Vector2.Distance(transform.position, waypoints[index].position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, step * Time.deltaTime);
            }
            else
            {
                if (index >= waypoints.Length - 1)
                    index = 0;
                else
                    index++;
            }
        }
    }
}
