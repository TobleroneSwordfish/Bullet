using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireForward : FireEffect
{
    public float force = 2;
    public override void OnFire(Projectile p)
    {
        p.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.Normalize(p.target - p.transform.position) * force, Vector3.zero);
        base.OnFire(p);
    }
}
