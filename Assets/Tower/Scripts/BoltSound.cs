using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSound : MonoBehaviour
{
    [SerializeField]
    AudioSource boltFire;

    [SerializeField]
    ParticleSystem boltParticle;

    int currentNumberOfParticles;

    void Update()
    {
        if (boltParticle.particleCount > currentNumberOfParticles)
        {
            boltFire.Play();
        }

        currentNumberOfParticles = boltParticle.particleCount;
    }
}
