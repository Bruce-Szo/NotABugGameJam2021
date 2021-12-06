using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSetup : MonoBehaviour
{
    public static int mushroomCount = 10;
    public RuleTile mushroomTile;
    // Start is called before the first frame update
    void Start()
    {
        Tilemap tilemap = GameObject.Find("/Grid/Tilemap").GetComponent<Tilemap>();
        for (int i = 0; i < mushroomCount; i++)
        {
            tilemap.SetTile(new Vector3Int(Random.Range(-4,4), Random.Range(-7, 8), 0), mushroomTile); //set tile at random location
        }
    }
}
