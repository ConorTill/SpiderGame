using UnityEngine;

namespace Assets.Scripts
{
    public class Raycast
    {
        public GameObject Cast(Vector3 origin, Vector3 destination)
        {
            RaycastHit2D ray = Physics2D.Raycast(origin, destination);
            if (ray)
            {
                return ray.transform.gameObject;
            }
            return null;
        }
    }
}
