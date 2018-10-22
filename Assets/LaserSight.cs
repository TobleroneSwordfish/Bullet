using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beams;

public class LaserSight : MonoBehaviour
{
    private Quaternion lastRot;
    private Vector3 lastPos;
    private Transform parent; //I'm lazy
    private GameObject[] beams;
    private List<GameObject> effectObjects;
    private static int layerMask = ~(1 << 8);

    public float length = 40;
    public GameObject reflectEffect;
    public GameObject beamObj;

    public Material basic;
    public Material onHit;

    // Use this for initialization
    void Start ()
    {
        parent = transform.parent;
        lastRot = parent.rotation;
        lastPos = parent.position;
        effectObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (parent.position != lastPos || parent.rotation != lastRot) //has the parent moved?
        {
            //clear all the old beam objects
            if (beams != null)
            {
                foreach (GameObject obj in beams)
                {
                    Destroy(obj);
                }
            }
            Beam.BeamInstance beamInstance = Beam.Project(beamObj, transform.position, parent.forward, length, transform, 3);
            beams = beamInstance.beamObjects;
            foreach (GameObject beam in beams)
            {
                RaycastHit hit;
                //start the ray at the back of the beam
                Vector3 origin = beam.transform.position - beam.transform.forward * ((beam.transform.localScale.z / 2) - .1f);
                if (Physics.Raycast(origin, beam.transform.forward, out hit, beam.transform.localScale.z + .1f, layerMask))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        foreach (Renderer rend in beam.GetComponentsInChildren<Renderer>())
                        {
                            rend.material = onHit;
                        }
                    }
                }
            }
            if (reflectEffect != null)
            {
                //clear all the old reflection effect objects
                foreach (GameObject effectObj in effectObjects)
                {
                    Destroy(effectObj);
                }
                foreach (Vector3 point in beamInstance.reflectionPoints)
                {
                    GameObject newObj = Instantiate<GameObject>(reflectEffect, point, Quaternion.identity, transform);
                    effectObjects.Add(newObj);
                }
            }
        }
        lastRot = parent.rotation;
        lastPos = parent.position;
	}   
}
