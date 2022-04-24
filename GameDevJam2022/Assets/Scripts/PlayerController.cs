using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float fallThresholdVelocity;

    private float moveHorizontal;
    private float moveVertical;





    private bool isGrounded;

    private bool wasGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");//grab type of input 
        moveVertical = Input.GetAxisRaw("Vertical");//grab type of input 

        if (!wasGrounded && isGrounded && rb2D.velocity.y < -fallThresholdVelocity)
        {
            Debug.Log("Damage");
        }
    }

    void FixedUpdate()//updating together w the physics engine inside unity, so it's not depending on the frame rate
    {
        //Left and Right
        if (moveHorizontal > 0f || moveHorizontal < 0f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed,0f), ForceMode2D.Impulse);
        }
        
        //Jumping
        if(isGrounded && moveVertical > 0f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        wasGrounded = isGrounded;
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isGrounded = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isGrounded = false;
        }
         
        

    }


}
