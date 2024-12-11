using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private float HorizontalMove = 0f;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private SpriteRenderer sprite;
    private UnityEngine.Vector3 moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {       
        MoveCharacter();

        if (transform.position.y < -9)
        {
            Death();
        }

        HorizontalMove = Input.GetAxis("Horizontal") * speed;
        anim.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            JumpCharacter();
            anim.SetBool("Jumping", true);
            isGrounded = false;

            
        }

    }


     void MoveCharacter()
    {
        moveInput = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += moveInput * speed * Time.deltaTime;

        if(moveInput.x != 0)
        {
            sprite.flipX = moveInput.x > 0 ? false : true;
            anim.transform.localScale = new UnityEngine.Vector3(Mathf.Abs(anim.transform.localScale.x) * (moveInput.x > 0 ? 1 : -1), anim.transform.localScale.y, anim.transform.localScale.z);
        }
    }

    private void JumpCharacter()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("Jumping", false);
            
        }

    }

    private void Death()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

