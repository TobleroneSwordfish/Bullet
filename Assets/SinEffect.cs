using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinEffect : FlightEffect
{
    public float frequency = .2f;
    public float amplitude = .1f;
    public override void EffectUpdate(Projectile p)
    {
        float sinVal = Mathf.Sin(Time.frameCount * frequency) * amplitude;
        transform.position += sinVal * transform.up;
        transform.RotateAround(transform.right, )
        base.EffectUpdate(p);
    }
}
