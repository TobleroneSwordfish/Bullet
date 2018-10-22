using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeathEffect : DeathEffect
{
    public override void OnDeath(GameObject obj)
    {
        print(obj + " Diededed");
        base.OnDeath(obj);
    }
}
