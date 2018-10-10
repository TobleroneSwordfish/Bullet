using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSetup : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Physics.IgnoreLayerCollision(8, 8);
	}
}
