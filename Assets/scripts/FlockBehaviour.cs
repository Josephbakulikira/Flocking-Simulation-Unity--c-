using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    public abstract Vector2 movement(Boids boid, List<Transform> context, Flock flock);

}
