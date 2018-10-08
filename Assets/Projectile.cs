using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public ImpactEffect impactEffect;
    public FireEffect fireEffect;
    public FlightEffect flightEffect;
    public Vector3 target;

    private bool inFlight = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (impactEffect != null)
        {
            impactEffect.OnImpact(this, collision);
        }
    }
    public void OnFire()
    {
        if (fireEffect != null)
        {
            fireEffect.OnFire(this);
        }
        inFlight = true;
    }
    private void Update()
    {
        if (inFlight && flightEffect != null) //is null checking each update actually bad?
        {
            flightEffect.Update(this);
        }
    }
}

public abstract class FireEffect : MonoBehaviour
{
    public FireEffect next;
    public virtual void OnFire(Projectile p)
    {
        if (next != null)
        {
            next.OnFire(p);
        }
    }
}

public abstract class ImpactEffect : MonoBehaviour
{
    public ImpactEffect next;
    public virtual void OnImpact(Projectile p, Collision c)
    {
        if (next == null)
        {
            GameObject.Destroy(p.gameObject);
        }
        else
        {
            next.OnImpact(p, c);
        }
    }
}

public abstract class FlightEffect : MonoBehaviour
{
    public FlightEffect next;
    public virtual void Update(Projectile p)
    {
        next.Update(p);
    }
}