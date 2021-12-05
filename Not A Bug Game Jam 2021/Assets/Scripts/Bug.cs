using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bug : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool head;
    public Bug nextBug;
    public Bug leaderBug;
    public Sprite BugLeaderSprite;

    public RuleTile mushroomTile;
    private Grid grid;
    private Tilemap tilemap;

    private Vector3 direction;
    private Vector3 lastDirection = Vector3.left;
    private Vector3 movePoint;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("/Grid").GetComponent<Grid>();
        tilemap = GameObject.Find("/Grid/Tilemap").GetComponent<Tilemap>();

        direction = Vector3.down;
        if (head) 
        {
            movePoint = transform.position;
            movePoint += direction;
        }
        else { 
            movePoint = leaderBug.transform.position;
        }
        //rotation = Quaternion.AngleAxis((Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90, Vector3.forward);
        RotateGameObject(movePoint, moveSpeed * 3, -90f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        RotateGameObject(movePoint, moveSpeed * 3, -90f);

        if (Vector3.Distance(transform.position, movePoint) == 0f) {
            FindDirection();
            if (head)
            {
                movePoint += direction;
            }
            else
            {
                movePoint = leaderBug.transform.position;
            }
        }
        
    }

    private void RotateGameObject(Vector3 target, float RotationSpeed, float offset)
    {
        //get the direction of the other object from current object
        Vector3 dir = target - transform.position;
        //get the angle from current direction facing to desired target
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //set the angle into a quaternion + sprite offset depending on initial sprite facing direction
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        //Roatate current game object to face the target using a slerp function which adds some smoothing to the move
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }

    private void FindDirection()
    {
        if (direction == Vector3.down) //if going down
        {
            if (lastDirection != Vector3.right && CheckPosition(transform.position + Vector3.right)) //if right is good
            {
                direction = Vector3.right; //set direction to right
                lastDirection = direction;
            }
            else if (CheckPosition(transform.position + Vector3.left)) //else if left is good
            {
                direction = Vector3.left; //set direction to left
                lastDirection = direction;
            }
        }
        else //direction is left or right
        {
            if(!CheckPosition(transform.position + direction)) //if next direction blocked else leave direction as is
            {
                direction = Vector3.down; //set direction to down
            }
        }
    }

    private bool CheckPosition(Vector3 pos) 
    {
        return !Physics2D.OverlapCircle(pos, 0.4f);
    }

    public void BecomeLeader() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BugLeaderSprite;
        head = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (nextBug != null) nextBug.BecomeLeader();
        tilemap.SetTile(grid.WorldToCell(movePoint), mushroomTile);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
