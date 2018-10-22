using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinVaried : FlightEffect
{
    public float switchTime = .5f;
    public float rotSpeed = 100;

    private Vector3 axis = Vector3.zero;
    private float elapsed;
	// Use this for initialization
	void Start ()
    {
	}

    // Update is called once per frame
    public override void EffectUpdate(Projectile p)
    {
        p.transform.Rotate(axis, Time.deltaTime * rotSpeed);
        elapsed += Time.deltaTime;
        if (elapsed >= switchTime)
        {
            axis = new Vector3(RandomAngle(), RandomAngle(), RandomAngle());
            Debug.Log("axis updated to " + axis);
            elapsed = 0;
        }
        base.EffectUpdate(p);
    }
    private float RandomAngle()
    {
        return (float)Random.Range(0, 1000) / 1000;
    }
}
