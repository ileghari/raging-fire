using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Peeing : MonoBehaviour
{
    public ParticleSystem Pee;
    private Transform aimTransform;
    protected bool letPlay = true;
    public float speed;
    private bool allowPee = true;
    

    private void Start()
    {
        aimTransform = transform.Find("Aim");
        Pee.GetComponent<ParticleSystem>().enableEmission = false;
    }

    IEnumerator TimeLapse() 
    {
        yield return new WaitForSeconds(0.1f);

        Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
        peeBar.peeLevel -= 0.1f;
        allowPee = true;
    }

    void Update()
    {
        HandleAiming();
        HandleShooting();
        
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

    }

    private void HandleShooting()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector2 halfScreen = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        Vector2 mouseXY  = new Vector2(Input.mousePosition.x - halfScreen.x,Input.mousePosition.y - halfScreen.y);
        float mouseDistFromCenter = Mathf.Sqrt(Mathf.Pow(mouseXY.x, 2) + Mathf.Pow(mouseXY.y, 2));
        Pee.startSpeed = mouseDistFromCenter * speed;
        Pee.startSpeed = Mathf.Min(Pee.startSpeed, 15);
        Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
        if (peeBar.peeLevel > 0) 
        {
            if (Input.GetMouseButton(0))
            {
                if (allowPee) 
                {
                allowPee = false;
                Pee.GetComponent<ParticleSystem>().enableEmission = true;
                StartCoroutine(TimeLapse());
                }
            }
            else
            {
                Pee.GetComponent<ParticleSystem>().enableEmission = false;
            }
        }
        else
        {
            Pee.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    // private void OnParticleTrigger() 
    // {

    //     Debug.Log("in peeing script");

    //     //Get all particles that entered a box collider
    //     List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
    //     int enterCount = Pee.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

    //     //Get all fires
    //     GameObject[] fires = GameObject.FindGameObjectsWithTag("fire");

    //     foreach (ParticleSystem.Particle particle in enteredParticles)
    //     {
    //         for (int i = 0; i < fires.Length; i++)
    //         {
    //             Collider2D collider = fires[i].GetComponent<Collider2D>();
    //             if (collider.bounds.Contains(particle.position))
    //             {
    //                 Destroy(fires[i]);
    //             }
    //         }
    //     }
    // }

}