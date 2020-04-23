using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/behaviours/Avoidance")]
public class AvoidanceBehaviour : FilteredBehaviour
{   
    public override Vector2 movement(Boids boid, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector2.zero;

        Vector2 avoidance_move = Vector2.zero;
        int _avoid = 0;
        List<Transform> filterContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform element in filterContext)
        {
            if(Vector2.SqrMagnitude(element.position - boid.transform.position) < flock.SquareAvoidanceRadius)
            {
                _avoid++;
                avoidance_move += (Vector2)(boid.transform.position - element.transform.position);

            }
        }
        if(_avoid > 0)
        {
            avoidance_move /= _avoid;
        }

        return avoidance_move;
    }
}
