using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter
{
    public override List<Transform> Filter(Boids boid, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform element in original)
        {
            Boids boid_AI = element.GetComponent<Boids>();
            if(boid_AI != null && boid_AI.BoidFlock == boid.BoidFlock)
            {
                filtered.Add(element);
            }
        }
        return filtered;
    }
}
