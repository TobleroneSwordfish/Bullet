using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Beams
{
    public static class Beam
    {
        //public GameObject beamPrefab;
        //public List<GameObject> beamObjects;
        //public List<Vector3> reflectionPoints;
        // Use this for initialization

        private static int layerMask = ~(1 << 8);
        public struct BeamInstance
        {
            public GameObject[] beamObjects;
            public Vector3[] reflectionPoints;
        }

        private static void Splinch(GameObject obj, Vector3 a, Vector3 b)
        {
            obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, Vector3.Distance(a, b));
            obj.transform.position = (a + b) / 2;
            obj.transform.LookAt(b);
        }

        public static BeamInstance Project(GameObject beamPrefab, Vector3 origin, Vector3 direction, float length, Transform transform = null, int maxIterations = 20)
        {
            BeamInstance instance;
            List<GameObject> beamObjects = new List<GameObject>();
            List<Vector3> reflectionPoints = new List<Vector3>();
            RaycastHit hit;
            bool hitSomething;
            int iterations = 1;
            while (hitSomething = Physics.Raycast(origin, direction, out hit, length, layerMask) && iterations < maxIterations)
            {
                GameObject newBeam1 = GameObject.Instantiate<GameObject>(beamPrefab);
                if (transform != null)
                {
                    newBeam1.transform.parent = transform;
                }
                beamObjects.Add(newBeam1);
                reflectionPoints.Add(hit.point);
                Splinch(newBeam1, origin, hit.point);
                length -= Vector3.Distance(hit.point, origin); //reduce length by length of new beam
                direction = direction - 2 * hit.normal * (Vector3.Dot(direction, hit.normal)); //reflect the direction about the normal
                origin = hit.point;
                iterations++;
            }
            GameObject newBeam = GameObject.Instantiate<GameObject>(beamPrefab);
            if (transform != null)
            {
                newBeam.transform.parent = transform;
            }
            Splinch(newBeam, origin, origin + direction * length);
            beamObjects.Add(newBeam);
            instance.beamObjects = beamObjects.ToArray();
            instance.reflectionPoints = reflectionPoints.ToArray();
            return instance;
        }
    }
}

