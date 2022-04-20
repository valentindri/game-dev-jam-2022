using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
        moveSpeed = 0.5f;
        jumpForce = 20f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");//grab type of input 
        moveVertical = Input.GetAxisRaw("Vertical");//grab type of input 
    }

    void FixedUpdate()//updating together w the phyisics engine inside unity, so it's not depending on the frame rate
    {
        if(moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed,0f), ForceMode2D.Impulse);
        }

        if(!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isJumping = false;
        } 
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isJumping = true;
        } 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bush")
        {
            Debug.Log("asd"+collision.gameObject.GetComponent<SpriteRenderer>());
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit"+ collision.gameObject.name);
    }
}
