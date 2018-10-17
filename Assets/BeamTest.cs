using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beams;

public class BeamTest : MonoBehaviour {
    public GameObject beamPrefab;
	// Use this for initialization
	void Start () {
        //Beam.Project(beamPrefab, transform.position, transform.forward, 40);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, Time.deltaTime * 360 * .1f);
	}
}
