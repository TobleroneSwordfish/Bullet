using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisAlt : MonoBehaviour
{
    private Dictionary<int, List<GameObject>> mainDebris;
    private GameObject[] currentDebris;
    private int currentLen = 0;
    private void Awake()
    {
        mainDebris = new Dictionary<int, List<GameObject>>();
        currentDebris = new GameObject[10];
    }
    public void AddDebris(int frames, params GameObject[] debris)
    {
        //mainDebris[Time.frameCount + frames].Add(debris);
    }
    private void LateUpdate()
    {
        //mainDebris.Add(Time.frameCount, currentDebris);
        currentLen = 0;
        currentDebris = new GameObject[10];
        if (mainDebris.ContainsKey(Time.frameCount))
        {
            foreach (GameObject obj in mainDebris[Time.frameCount])
            {
                Destroy(obj);
            }
        }
    }
}
