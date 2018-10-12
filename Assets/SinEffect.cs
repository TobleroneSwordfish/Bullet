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
        transform.Rotate(transform.right, Mathf.Cos(Time.frameCount * frequency) * amplitude);//DOCUMENTATION AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        //THIS IS LITERALLY MATHS, YOU DONkey
        //I thought you were gonna say "this is literally maths, you donkey" (been watching too much gordon ramsey)
        //well now it's documented
        //Very well documented, 4 lines of comments for one cos
        base.EffectUpdate(p);
    }
}
