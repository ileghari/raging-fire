using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float healthLevel = 3;
    public Image healthBar1;
    public Image healthBar2;
    public Image healthBar3;
    private bool allowDamage = true;

    IEnumerator HealthTicker() {
        yield return new WaitForSeconds(1); 

        healthLevel--;
        allowDamage = true;
    }


    void Update()
    {
        if (GameObject.Find("Bunny").GetComponent<PlayerCollision>().onFire == true)
        {
            if(allowDamage)
            {
                allowDamage = false;
                StartCoroutine(HealthTicker());

            }
            
        }
        if(healthLevel == 2)
        {
            healthBar3.color = Color.black;
        }
        if (healthLevel == 1)
        {
            healthBar2.color = Color.black;
        }
        if (healthLevel == 0)
        {
            healthBar1.color = Color.black;
            SceneManager.LoadScene("Game Menu");
        }

        
    }

}
