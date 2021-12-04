using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject ammo;
    public float jumpAmount;
    public float movementSpeed;
    public float bulletSpeed;
    public float shootSpeed;
    Rigidbody2D rb;
    bool shooting = false;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameObject aM = GameObject.FindWithTag("AudioManager");
        audioManager = aM.GetComponent<AudioManager>();
    }

    private void Update()
    {

        if (Input.GetButton("Jump") && !jumping) {
            Jump();
        }
        if (Input.GetButton("Fire1") && !shooting)
        {
            Shoot();
        }
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rb.velocity.y);

    }
    void Jump()
    {
        jumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
            {
                //collision was from below
                jumping = false;
            }
        }
    }
    void Shoot()
    {
        StartCoroutine(Shooting());

        GameObject bullet = Instantiate(ammo);
        Rigidbody2D rigidBullet = bullet.GetComponent<Rigidbody2D>();
        rigidBullet.velocity = new Vector2(bullet.transform.up.x, bullet.transform.up.y).normalized * bulletSpeed;
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);

        audioManager.PlayShootEffect();

    }
    IEnumerator Shooting()
    {
        shooting = true;
        yield return new WaitForSeconds(1f / shootSpeed);
        shooting = false;
    }
}
