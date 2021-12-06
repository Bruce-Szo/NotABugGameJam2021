using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform head;
    public Transform body;
    public static int bodyLength = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnSnake();
    }

    private void FixedUpdate()
    {
        if (!GameObject.FindWithTag("Bug"))
        {
            spawnSnake();
        }
    }


    void spawnSnake()
    {
        Transform firstBug = Instantiate(head, spawnPoint.position, spawnPoint.rotation); // Make first bug
        firstBug.name = "0"; // Namer first bug
        for (int i = 0; i < bodyLength; i++)
        {
            // Makes one bug 1 unit above the previous bug
            Transform nextBug = Instantiate(body, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1 * (1 + i), spawnPoint.position.z), spawnPoint.rotation);
            nextBug.name = (i + 1).ToString();

            firstBug.GetComponent<Bug>().nextBug = nextBug.GetComponent<Bug>(); // Allows first bug to be able to communicate with second bug
            nextBug.GetComponent<Bug>().leaderBug = firstBug.GetComponent<Bug>(); //Make doublely linked list
            firstBug = nextBug; // Start over with the second bug parenting the next, etc.
        }
    }
}
