using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Filter/Obsctacle")]
public class ObstacleFilter : ContextFilter
{

    public LayerMask mask;

    public override List<Transform> Filter(Boids boid, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform element in original)
        {
            if(mask == (mask| (1 << element.gameObject.layer)))
            {
                filtered.Add(element);

            }
        }
        return filtered;
    }

}
