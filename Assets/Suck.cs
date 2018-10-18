using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    List<GameObject> objects;
    private void Start()
    {
        objects = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            objects.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objects.Remove(other.gameObject);
    }
    private void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.transform.position += (transform.position - obj.transform.position) * Time.deltaTime * (1 - 1 / Vector3.Distance(transform.position, obj.transform.position));
            }
            
        }
    }
}
