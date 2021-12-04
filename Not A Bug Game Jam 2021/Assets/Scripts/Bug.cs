using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public bool head;
    public Bug nextBug;
    public Sprite BugLeaderSprite;

    Vector3 nextLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BecomeLeader() {
        gameObject.GetComponent<SpriteRenderer>().sprite = BugLeaderSprite;
        head = true;
    }
}
