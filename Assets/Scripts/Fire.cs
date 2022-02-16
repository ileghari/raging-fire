using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private Vector3Int position;

    private TileData data;

    private FireManager fireManagerObj;

    private float burnTimeCounter, spreadIntervalCounter;

    void Start() {

        fireManagerObj = FindObjectOfType<FireManager>();

    }

    public ParticleSystem Pee;


    public void StartBurning(Vector3Int position, TileData data, FireManager fm) {

        this.position = position;
        this.data = data;
        fireManagerObj = fm;

        burnTimeCounter = data.burnTime;
        spreadIntervalCounter = data.spreadInterval;
    }  

    private void OnParticleTrigger() 
    {


        Debug.Log("happened");
        //Get all particles that entered a box collider
        List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        int enterCount = Pee.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

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


    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(data);

        // burnTimeCounter -= Time.deltaTime; // decrement it by time.deltaTime every frame

        // //whenever burnTimeCounter is 0 or lower, we inform fire manager that its finished burning
        // if (burnTimeCounter <= 0) {
        //     fireManagerObj.GetComponent<FireManager>().FinishedBurning(position);
        //     //Destroy(gameObject);
        // } 

        spreadIntervalCounter -= Time.deltaTime;
        if (spreadIntervalCounter <= 0) {

            //when it reaches 0 we reset it and tell fire manager when to spread
            if (data == null) {
                return; 
            } else {
            spreadIntervalCounter = data.spreadInterval;
            fireManagerObj.GetComponent<FireManager>().TryToSpread(position, data.spreadChance);
            }
        }
    }
}



// for every type of tile we need a scriptable object for that tile (in that scriptable object we need to add the tile sprite)