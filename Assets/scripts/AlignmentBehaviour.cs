using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/behaviours/Alignment")]
public class AlignmentBehaviour : FilteredBehaviour
{
    public override Vector2 movement(Boids boid, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return boid.transform.up;

        Vector2 alignment_move = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform element in filterContext)
        {
            alignment_move += (Vector2)element.transform.up;
        }
        alignment_move /= context.Count;

        return alignment_move;
    }
}
