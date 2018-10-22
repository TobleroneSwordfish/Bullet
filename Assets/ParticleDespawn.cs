using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelfDestroy)), RequireComponent(typeof(ParticleSystem))]
public class ParticleDespawn : MonoBehaviour
{
	void Awake ()
    {
        SelfDestroy destroyScript = GetComponent<SelfDestroy>();
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        destroyScript.life = particleSystem.main.duration + particleSystem.main.startLifetime.constantMax;
	}
}
