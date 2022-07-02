using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public ParticleSystem bulletparticles;
    public GameObject sparks;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        int events = bulletparticles.GetCollisionEvents(other, colEvents);

        for (int i = 0; i < events; i++) 
        {
            Instantiate(sparks, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }
    }
}
