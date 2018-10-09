using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Launcher : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject projectile;

    protected virtual void Fire()
    {
        GameObject newProjectile = Instantiate<GameObject>(projectile);
        newProjectile.GetComponent<Projectile>().OnFire(this);
    }
}
