using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformUP : MonoBehaviour
{
    public float speed;
    private Vector3 pos;
    private Vector3 targetPos;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        pos = transform.position;
        targetPos = pos + Vector3.up * 10f;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            if (targetPos == pos + Vector3.up * 10f)
            {
                targetPos = pos;
            }
            else
            {
                targetPos = pos + Vector3.up * 10f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = true;
            collision.gameObject.transform.parent = transform;
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

