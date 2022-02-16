using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeCollision : MonoBehaviour
{

    public ParticleSystem Pee;


    private void OnParticleTrigger() 
    {

        Debug.Log("in peeing script");

        //Get all particles that entered a box collider
        List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        int enterCount = Pee.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

        Debug.Log(enterCount);

        //Get all fires
        GameObject[] fires = GameObject.FindGameObjectsWithTag("fire");

        foreach (ParticleSystem.Particle particle in enteredParticles)
        {
            for (int i = 0; i < fires.Length; i++)
            {
                Collider2D collider = fires[i].GetComponent<Collider2D>();
                if (collider.bounds.Contains(particle.position))
                {
                    Destroy(fires[i]);
                }
            }
        }
    }
}
