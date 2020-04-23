using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/behaviours/Cohesion")]
public class CohesionBehaviour : FilteredBehaviour
{
    public override Vector2 movement(Boids boid, List<Transform> context, Flock flock)
    {
        if(context.Count == 0)
            return Vector2.zero;

        Vector2 cohesion_move = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform element in filterContext)
        {
            cohesion_move += (Vector2)element.position;
        }
        cohesion_move /= context.Count;

        cohesion_move -= (Vector2)boid.transform.position;
        return cohesion_move;
    }
}
