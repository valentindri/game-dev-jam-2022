using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    
    private bool isGrounded;
    private float moveHorizontal;
    private float moveVertical;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");//grab type of input 
        moveVertical = Input.GetAxisRaw("Vertical");//grab type of input 

    }

    void FixedUpdate()//updating together w the physics engine inside unity, so it's not depending on the frame rate
    {

        if (moveHorizontal > 0f || moveHorizontal < 0f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed,0f), ForceMode2D.Force);
        }

        if(isGrounded && moveVertical > 0f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isGrounded = true;
        }
    }









}
