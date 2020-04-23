using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/behaviours/Boundary")]
public class Boundary : FlockBehaviour
{
    public Vector2 center;
    public float radius = 15f;

    public override Vector2 movement(Boids boid, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = center - (Vector2)boid.transform.position;
        float t = centerOffset.magnitude / radius;
        if(t < 0.9f)
        {
            return Vector2.zero;

        }
        return centerOffset * t * t;
    }
}
