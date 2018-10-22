using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Debris : MonoBehaviour
{
    //public delegate void ExitMethod(GameObject obj);
    public void AddDebris(float life, Action<GameObject> method, params GameObject[] objects)
    {
        StartCoroutine(Delet(life, method, objects));
    }
    public void AddDebris(int life, Action<GameObject> method, params GameObject[] objects)
    {
        StartCoroutine(DeletFrames(life, method, objects));
    }

    private IEnumerator DeletFrames(int frames, Action<GameObject> method, params GameObject[] objects)
    {
        int end = Time.frameCount + frames;
        yield return new WaitUntil(() => Time.frameCount == end);
        foreach (GameObject obj in objects)
        {
            method(obj);
            Destroy(obj);
        }
    }

    private IEnumerator Delet(float life, Action<GameObject> method, params GameObject[] objects)
    {
        yield return new WaitForSeconds(life);
        foreach (GameObject obj in objects)
        {
            method(obj);
            Destroy(obj);
        }
    }
}
