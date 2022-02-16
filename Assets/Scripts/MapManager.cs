using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap map;

    // creating a list storing all scriptable objects we created
    [SerializeField]
    private List<TileData> tileDatas;

    // connection between each tile base and its tile data stored in a dictionary
    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake() {
        
        dataFromTiles = new Dictionary<TileBase, TileData>();

        // go through tiledata and for each tileData go through tileList for which we create an entry in dict (tile: tileData)
        foreach (var tileData in tileDatas) {

            foreach (var tile in tileData.tiles) {
                
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    
    

    //takes position of tilemap and returns tile data
    public TileData GetTileData(Vector3Int tilePosition) {

        // gets the tile type at that position
        TileBase tile = map.GetTile(tilePosition);

        //looks up connected tile data from the dictionary + checks if there is a tile and returns none if there isn't (fire might spread to tiles that don't exist)

        if (tile == null) 
            return null;
        else 
            {
            //Debug.Log(dataFromTiles);
            //Debug.Log(dataFromTiles[tile]);
            return dataFromTiles[tile];
            }

    }
}
