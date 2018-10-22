using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Debris;

public class DebrisScript : MonoBehaviour
{
    private void Awake()
    {
        DebrisManager.instance = this;
    }
    public void AddDebrisSecs(float life, Action<GameObject> method = null, params GameObject[] objects)
    {
        if (method != null)
        {
            StartCoroutine(Delet(life, method, objects));
        }
        else
        {
            StartCoroutine(Delet(life, (obj) => { }, objects));
        }
    }
    public void AddDebrisFrames(int life, Action<GameObject> method = null, params GameObject[] objects)
    {
        if (method != null)
        {
            StartCoroutine(DeletFrames(life, method, objects));
        }
        else
        {
            StartCoroutine(DeletFrames(life, (obj) => { }, objects));
        }
    }

    private IEnumerator DeletFrames(int frames, Action<GameObject> method, params GameObject[] objects)
    {
        int end = Time.frameCount + frames;
        yield return new WaitUntil(() => Time.frameCount == end);
        RemoveObjects(method, objects);
    }

    private IEnumerator Delet(float life, Action<GameObject> method, params GameObject[] objects)
    {
        yield return new WaitForSeconds(life);
        RemoveObjects(method, objects);
    }
    private void RemoveObjects(Action<GameObject> method, params GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            method(obj);
            Destroy(obj);
        }
    }
}
