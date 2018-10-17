//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LaserColourChange : MonoBehaviour
//{

//    public GameObject topLevelObject;

//    private Collider col;
//    private Renderer rend;
//    private int contacts = 0;
//    private bool firstFrame = true;
//    private static int layerMask = ~(1 << 8);
//    // Use this for initialization
//    void Awake ()
//    {
//        col = GetComponentInChildren<Collider>();
//        rend = GetComponentInChildren<Renderer>();
//	}

//    //private void OnTriggerEnter(Collider other)
//    //{
//    //    if (other.CompareTag("Enemy"))
//    //    {
//    //        contacts++;
//    //        rend.material = onHit;
//    //    }
//    //}
//    //private void OnTriggerExit(Collider other)
//    //{
//    //    if (other.CompareTag("Enemy"))
//    //    {
//    //        contacts--;
//    //        if (contacts <= 0)
//    //        {
//    //            rend.material = basic;
//    //        }
//    //    }
//    //}

//    // Update is called once per frame
//    void LateUpdate ()
//    {
//        if (firstFrame)
//        {
//            RaycastHit hit;
//            //start the ray at the back of the beam
//            Vector3 origin = topLevelObject.transform.position - topLevelObject.transform.forward * (topLevelObject.transform.localScale.z / 2);
//            if (Physics.Raycast(origin, topLevelObject.transform.forward, out hit, topLevelObject.transform.localScale.z, layerMask))
//            {
//                if (hit.collider.CompareTag("Enemy"))
//                {
//                    rend.material = onHit;
//                }
//            }
//            firstFrame = false;
//        }
//    }
//}
