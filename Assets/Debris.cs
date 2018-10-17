using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public void AddDebris(float life, params GameObject[] objects)
    {
        StartCoroutine(Delet(life, objects));
    }
    public void AddDebris(int life, params GameObject[] objects)
    {
        StartCoroutine(DeletFrames(life, objects));
    }

    private IEnumerator DeletFrames(int frames, params GameObject[] objects)
    {
        int end = Time.frameCount + frames;
        yield return new WaitUntil(() => Time.frameCount == end);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    private IEnumerator Delet(float life, params GameObject[] objects)
    {
        yield return new WaitForSeconds(life);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
