using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semi : Launcher
{
    public float refireTime;
    private float lastFire;

	// Use this for initialization
	void Start ()
    {
        lastFire = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown())
	}
}
