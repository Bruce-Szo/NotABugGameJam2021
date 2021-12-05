using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSetup : MonoBehaviour
{
    public static int mushroomCount;
    public RuleTile mushroomTile;
    // Start is called before the first frame update
    void Start()
    {
        Tilemap tilemap = GameObject.Find("/Grid/Tilemap").GetComponent<Tilemap>();
        for (int i = 0; i < mushroomCount; i++)
        {
            tilemap.SetTile(new Vector3Int(Random.Range(-10,10), Random.Range(-3, 5), 0), mushroomTile); //set tile at random location
        }
    }
}
