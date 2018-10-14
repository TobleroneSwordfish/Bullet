using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public GameObject target;
    public GameObject beam;
    public float length = 40;
	// Use this for initialization
	void Start ()
    {
        Project(transform.position, target.transform.position - transform.position, length);
	}
	

    private void Splinch(GameObject obj, Vector3 a, Vector3 b)
    {
        obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, Vector3.Distance(a, b));
        obj.transform.position = (a + b) / 2;
        obj.transform.LookAt(b);
    }

    public void Project(Vector3 origin, Vector3 direction, float length)
    {
        RaycastHit hit;
        GameObject newBeam = Instantiate<GameObject>(beam);
        newBeam.transform.parent = transform;
        bool hitsomething = Physics.Raycast(transform.position, direction, out hit, length);
        if (hitsomething)
        {
            float distance = Vector3.Distance(hit.point, transform.position);
            if (distance <= length)
            {
                Splinch(newBeam, origin, hit.point);
                Vector3 reflection = direction - 2 * hit.normal * (Vector3.Dot(direction, hit.normal));
                Project(hit.point, Vector3.Normalize(reflection), length - distance);
            }
        }
        else
        {
            Splinch(newBeam, origin, origin + direction * length);
        }
    }
}
