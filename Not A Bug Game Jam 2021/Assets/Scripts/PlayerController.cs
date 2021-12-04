using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    }

    void FixedUpdate()
    {
        rb.velocity = (transform.right * movementSpeed * Input.GetAxisRaw("Horizontal"));
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
    }
    void Jump()
    {
        jumping = true;
        rb.AddForce(Vector2.up * jumpAmount);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jumping = false;
    }
    void Shoot()
    {
        StartCoroutine(Shooting());

        GameObject bullet = Instantiate(ammo);
        Rigidbody2D rigidBullet = bullet.GetComponent<Rigidbody2D>();
        rigidBullet.velocity = new Vector2(bullet.transform.up.x, bullet.transform.up.y).normalized * bulletSpeed;
        bullet.transform.position = transform.position;

    }
    IEnumerator Shooting()
    {
        shooting = true;
        yield return new WaitForSeconds(1f / shootSpeed);
        shooting = false;
    }
}
