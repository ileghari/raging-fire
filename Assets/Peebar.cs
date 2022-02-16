using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Peebar : MonoBehaviour
{
    public float peeLevel = 0;
    public Image peeBar;
    private float coeffiecient;


    void Update()
    {
        if (peeLevel > 7 ^ peeLevel < 0) {
            return;
        }

        coeffiecient = peeLevel / 10; 
        peeBar.transform.localScale = new Vector3(0.15f, coeffiecient, 0);

       

    }




}
