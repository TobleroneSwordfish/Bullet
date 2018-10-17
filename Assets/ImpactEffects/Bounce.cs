using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : ImpactEffect
{
    public int maxBounces = 3;
    private int bounces = 1;
    public override void OnImpact(Projectile p, Collision c)
    {
        if (bounces < maxBounces)
        {
            bounces++;
        }
        else
        {
            base.OnImpact(p, c);
        }
    }
}
