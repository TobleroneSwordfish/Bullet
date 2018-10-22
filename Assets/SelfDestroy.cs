using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debris;

public class SelfDestroy : MonoBehaviour
{
    public float life;
    private void Awake()
    {
        DebrisManager.AddDebrisTime(life, null, gameObject);
    }
}
