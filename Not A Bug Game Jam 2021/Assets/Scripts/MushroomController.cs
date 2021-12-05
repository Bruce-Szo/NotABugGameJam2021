using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    int health = 4;
    public Sprite[] sprites = new Sprite[4];
    SpriteRenderer r;
    private void Start()
    {
        r = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //destroy bullet gameobject
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else { 
            r.sprite = sprites[health - 1]; //update image to damaged one
        }
        
    }
}
