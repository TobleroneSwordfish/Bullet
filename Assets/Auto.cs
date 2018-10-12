using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : Launcher
{
    public float refireTime = .2f;
    public int mouseButton = 0;
    private float lastFire;

    // Use this for initialization
    void Start()
    {
        lastFire = Time.time;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            StartCoroutine("Pew");
        }
    }
    IEnumerator Pew() //pews
    {
        while (true)
        {
            if (Input.GetMouseButton(mouseButton) && Time.time > lastFire + refireTime)
            {
                Fire();
                lastFire = Time.time;
                yield return new WaitForSeconds(refireTime);
            }
            else
            {
                yield break;
            }
        }
    }
}
