using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semi : Launcher
{
    public float refireTime;
    public int mouseButton = 0;
    private float lastFire;

	// Use this for initialization
	void Start ()
    {
        lastFire = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(mouseButton) && Time.time - lastFire > refireTime)
        {
            lastFire = Time.time;
            Fire();
        }
	}
}
