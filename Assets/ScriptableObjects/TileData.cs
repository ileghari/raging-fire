using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{

    public TileBase[] tiles;

    public float spreadChance, spreadInterval, burnTime;

    public bool canBurn;


}

// spreadChance = determines chance of fire spreading to neighbouring tile
// spreadInterval = interval that we check every x seconds if fire is burning
// burnTime = how long it burns for (not in our app cause we don't have burnt tiles after fire)