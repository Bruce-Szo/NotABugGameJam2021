using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool isGrounded = false;
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameObject aM = GameObject.FindWithTag("AudioManager");
        audioManager = aM.GetComponent<AudioManager>();
        r = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && !jumping && isGrounded) {
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
        jumping = false;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down);
        isGrounded = hit2D.collider != null && Mathf.Abs(transform.position.y - hit2D.point.y) < 0.5f;
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
    private void FixedUpdate()
    {
        if (!r.isVisible)
        {
            MapSetup.mushroomCount += 5;
            CentipedeSpawner.bodyLength += 5;
            Bug.moveSpeed += 0.2f;
            Scoreboard.score += 10000;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
