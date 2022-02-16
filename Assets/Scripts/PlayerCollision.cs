using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public bool onFire;
    

    //when player enters the fire
    void OnTriggerEnter2D(Collider2D otherCollider) {

        if (otherCollider.gameObject.tag == "fire") {
            onFire = true;
            Debug.Log("entering fire" + onFire);
        }

    
    }

    void OnTriggerExit2D(Collider2D otherCollider) {
        if (otherCollider.gameObject.tag == "fire") {
            onFire = false;
            Debug.Log("leaving fire" + onFire);
        }
    }
}

