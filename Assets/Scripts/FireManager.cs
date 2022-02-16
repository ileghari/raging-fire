using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class FireManager : MonoBehaviour
{

    [SerializeField]
    public Tilemap map;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Fire firePrefab;
    public bool wave = true;
    private List<Vector3Int> activeFires = new List<Vector3Int>(); // keeping track of all burnt tiles in a list

    Vector3Int[] fireLoc = new[] { new Vector3Int(-8, -35, 0), new Vector3Int(-50, -46, 0), new Vector3Int(-10, -10, 0), new Vector3Int(-51, -10, 0), new Vector3Int(10, 10, 0), new Vector3Int(10, -20, 0) };
    // public void FinishedBurning(Vector3Int position) {

    //     //map.SetTile(position, ashTile);
    //     activeFires.Remove(position);
    // }


    // need to go through all 9 neighbouring tiles
    // going one tile to left by subtracting one from x position, by adding one, we go one tile to right

    public TextMeshProUGUI textMesh;
    public int score = 0;


    public void TryToSpread(Vector3Int position, float spreadChance) {

        //make a nested loop, first from left to right then inside up to down --> goes from -1, to 0 to +1
        for (int x = position.x - 1; x < position.x + 2; x++) {
            for (int y = position.y - 1; y < position.y + 2; y++) {

                TryToBurnTile(new Vector3Int(x, y, 0));
        }
        }

        void TryToBurnTile(Vector3Int tilePosition) {

            // if its in the already burnt list, we just exit the function
            if (activeFires.Contains(tilePosition)) return; 

            TileData data = mapManager.GetTileData(tilePosition);

            // if tile can burn, we need to check the spread chance - get a random number between 0 and 100 and if number is lower or equal to spread chance tile will be set on fire
            if ( data != null && data.canBurn) {
                if(UnityEngine.Random.Range(0f, 100f) <= data.spreadChance)  
                    SetTileOnFire(tilePosition, data);
                
            }
        }
    }

    private void SetTileOnFire(Vector3Int tilePosition, TileData data) {

        // instantiates prefab and then in fire script start burning runs
        Fire newFire = Instantiate(firePrefab);
        newFire.name = tilePosition.ToString();
        newFire.transform.position = map.GetCellCenterWorld(tilePosition);
        // change tile to burnt space line missing here
        newFire.StartBurning(tilePosition, data, this);

        // grid position added to active fire list
        activeFires.Add(tilePosition);
    }

    private void RemoveTileOnFire(Vector3Int tilePosition, TileData data) {
        // Debug.Log("game object");
        // Debug.Log(gameObject);

        // Tilemap tilemap = map.GetComponent<Tilemap>();
        // tilemap.SetTile(tilePosition, null);

        //Destroy(gameObject);

        GameObject tileToRemove = GameObject.Find(tilePosition.ToString());
        // Debug.Log("printing game object");
        // Debug.Log(tileToRemove);
        Destroy(tileToRemove);

        return;
    }




    IEnumerator TimeLapse()
    {

        int num = Random.Range(0, 5);
        TileData data = mapManager.GetTileData(fireLoc[num]);
        SetTileOnFire(fireLoc[num], data);

        yield return new WaitForSeconds(15f);
        score += 1;
        textMesh.text = "Wave:" + score;
        
        wave = true;
    }



    // way to start the fire

    private void Update() {

        if (wave == true)
        {
            wave = false;
            StartCoroutine(TimeLapse());
           
            
        }
        // checks for mouse click and converts mouse position to grid position, gets corresponding tile data and uses that to trigger the set on fire function
        if (Input.GetMouseButtonDown(1)) {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileData data = mapManager.GetTileData(gridPosition);

            if (!activeFires.Contains(gridPosition)) {
                
                SetTileOnFire(gridPosition, data);
                Debug.Log(gridPosition);
            } 
        }

        if (Input.GetMouseButton(0)) {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileData data = mapManager.GetTileData(gridPosition);

            Peebar peeBar = GameObject.Find("PeeBunny").GetComponent<Peebar>();
            if(peeBar.peeLevel > 0){
            RemoveTileOnFire(gridPosition, data);
            }
        }
    }
}
