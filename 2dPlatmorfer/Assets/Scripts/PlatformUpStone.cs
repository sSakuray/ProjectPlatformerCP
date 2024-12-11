using UnityEngine;

public class PlatformUpStone : MonoBehaviour
{
    public float liftAmount = 17f;
    public float liftSpeed = 4f;

    public float moveRightAmount = 13f;
    public float moveSpeed = 2f;

    private bool isLifting = false;
    private bool isMovingRight = false;
    private float targetY;
    private float targetX;

    private bool isPlayerOnPlatform = false;

    void Start()
    {
        targetY = transform.position.y;
        targetX = transform.position.x;
    }

    void Update()
    {
        if (isLifting)
        {
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, liftSpeed * Time.deltaTime), transform.position.z);

            if (transform.position.y == targetY)
            {
                isLifting = false;
            }
        }


        if (isMovingRight)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);

            if (transform.position.x == targetX)
            {
                isMovingRight = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            if (!isLifting)
            {
                targetY = transform.position.y + liftAmount;
                isLifting = true; 
            }
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            collision.gameObject.transform.parent = transform;
            if (!isLifting && transform.position.y == targetY && !isMovingRight)
            {
                targetX = transform.position.x + moveRightAmount; 
                isMovingRight = true; 

            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = false;
        
            if (transform.gameObject.activeInHierarchy)
            {
                collision.gameObject.transform.parent = null;
            }

        }
    }
}

