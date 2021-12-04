using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!r.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
