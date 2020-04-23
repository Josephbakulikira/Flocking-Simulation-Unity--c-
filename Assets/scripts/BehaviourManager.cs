using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/behaviourManager")]
public class BehaviourManager : FlockBehaviour
{
    public FlockBehaviour[] behaviours;
    public float[] weights;
    public override Vector2 movement(Boids boid, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviours.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;

        }

        Vector2 boid_move = Vector2.zero;
        for (int i = 0; i < behaviours.Length; i++)
        {
            Vector2 partial_move = behaviours[i].movement(boid, context, flock) * weights[i];
            
            if(partial_move.sqrMagnitude > weights[i] * weights[i])
            {
                partial_move.Normalize();
                partial_move *= weights[i];
            }
            boid_move += partial_move;
        }

        return boid_move;
    }
}
