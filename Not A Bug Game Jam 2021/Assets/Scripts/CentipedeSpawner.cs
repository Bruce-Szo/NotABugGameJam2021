using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform head;
    public Transform body;
    public int bodyLength;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(head, spawnPoint.position, spawnPoint.rotation);
        for (int i = 0; i < bodyLength; i++) {
            Instantiate(body, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1*(1+i), spawnPoint.position.z), spawnPoint.rotation);
        }
    }
}
