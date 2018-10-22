using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : DeathEffect
{
    public GameObject obj;
    public override void OnDeath(GameObject obj)
    {
        Instantiate<GameObject>(this.obj, obj.transform.position, obj.transform.rotation);
    }
}
