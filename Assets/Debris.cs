using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public void AddDebris(float life, params GameObject[] objects)
    {
        StartCoroutine(Delet(life, objects));
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
