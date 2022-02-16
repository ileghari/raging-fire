using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    private int animNumber;
    private Vector3 position;
    //private float peeBar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        position = gameObject.transform.position;

        animNumber = 2;
        
    }

    void Update()
    {
        var MousePos = GameObject.Find("Bunny").transform.position;
        float xDist = position.x - MousePos.x;
        float yDist = position.y - MousePos.y;
        float dist = Mathf.Sqrt(Mathf.Pow(xDist, 2)+ Mathf.Pow(yDist, 2));

        if (Input.GetKeyDown(KeyCode.K) && animNumber == 2 && dist < 2)
        {
            GetComponent<Animator>().Play("WaterAnimation2");
            animNumber++;
            Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
            peeBar.peeLevel ++;
            Debug.Log(peeBar.peeLevel);
            return;
        }
        if (Input.GetKeyDown(KeyCode.K) && animNumber == 3 && dist < 2)
        {
            GetComponent<Animator>().Play("WaterAnimation 3");
            animNumber++;
            Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
            peeBar.peeLevel ++;
            Debug.Log(peeBar.peeLevel);
            return;
        }
        if (Input.GetKeyDown(KeyCode.K) && animNumber == 4 && dist < 2)
        {
            GetComponent<Animator>().Play("WaterAnimation4");
            animNumber++;
            Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
            peeBar.peeLevel ++;
            Debug.Log(peeBar.peeLevel);
            return;
        }
        if (Input.GetKeyDown(KeyCode.K) && animNumber == 5 && dist < 2)
        {
            GetComponent<Animator>().Play("WaterAnimation5");
            animNumber++;
            Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
            peeBar.peeLevel ++;
            Debug.Log(peeBar.peeLevel);
            return;
        }
    }
}
