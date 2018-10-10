using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireForward : FireEffect
{
    public float force = 10;
    public override void OnFire(Projectile p)
    {
        p.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * force, Vector3.zero);
        base.OnFire(p);
    }
}
