﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Debris;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public ImpactEffect impactEffect;
    public FireEffect fireEffect;
    public FlightEffect flightEffect;
    public DeathEffect deathEffect;
    public Vector3 target;
    public float lifetime = 2;
    //public DebrisScript debrisManager;
    [System.NonSerialized]
    public Launcher launcher;
    private bool inFlight = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (impactEffect != null)
        {
            impactEffect.OnImpact(this, collision);
        }
    }
    public void OnFire(Launcher launcher)
    {
        this.launcher = launcher;
        inFlight = true;
        if (fireEffect != null)
        {
            fireEffect.OnFire(this);
        }
        //print("Projectile gameObject: " + gameObject);
        if (deathEffect != null)
        {
            DebrisManager.AddDebrisTime(lifetime, (GameObject obj) => deathEffect.OnDeath(obj), gameObject);
        }
        else
        {
            DebrisManager.AddDebrisTime(lifetime, (obj) => { }, gameObject);
        }
    }
    private void Update()
    {
        if (inFlight && flightEffect != null) //is null checking each update actually bad?
        {
            flightEffect.EffectUpdate(this);
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
    public virtual void EffectUpdate(Projectile p)
    {
        if (next != null)
        {
            next.EffectUpdate(p);
        }
    }
}

public abstract class DeathEffect : MonoBehaviour
{
    public DeathEffect next;
    public virtual void OnDeath(GameObject obj)
    {
        if (next != null)
        {
            next.OnDeath(obj);
        }
    }
}