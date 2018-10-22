using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : Launcher
{
    public float refireTime;
    private float timePassed;
	// Update is called once per frame
	void Update ()
    {
        timePassed += Time.deltaTime;
        if (timePassed > refireTime)
        {
            Fire();
            timePassed = 0;
        }
	}
}
