using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flowers : MonoBehaviour
{
   public int flowerHealth = 3;
   public Image flower1;
   public Image flower2;
   public Image flower3;


   void Update()
   {
      if (flowerHealth == 2)
      {
        flower3.color = new Color(1, .92f, 0.016f, 1);
      }
      if (flowerHealth == 1)
      {
        flower2.color = new Color(1, .92f, 0.016f, 1);
      }
      if (flowerHealth == 0)
      {
        flower1.color = new Color(1, .92f, 0.016f, 1);
      }

      if (Input.GetKeyDown(KeyCode.Space) && flowerHealth > 0)
      {
        flowerHealth--;
      }
   }

}
