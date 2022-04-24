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
    [SerializeField] private Sprite DeadEgg;

    private Vector2 respawnPoint;
    private float moveHorizontal;
    private float moveVertical;





    private bool isGrounded;

    private bool wasGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");//grab type of input 
        moveVertical = Input.GetAxisRaw("Vertical");//grab type of input 
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


        if (collision.tag == "Hole")
        {
            Debug.Log("Fall into hole...Respawning to "+ respawnPoint);
            transform.position = respawnPoint;
        }

        if (collision.gameObject.tag != "Bush")
        {
            float playerVelocity = Mathf.Abs(rb2D.velocity.y);
            Debug.Log("plyer velocity" + playerVelocity);

            if (!wasGrounded && isGrounded && playerVelocity > fallThresholdVelocity)
            {
                GetDamage(playerVelocity);
                Debug.Log("Damage" + playerVelocity);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isGrounded = false;
        }
         
        

    }

    void GetDamage(float damage)
    {
        Debug.Log("Received damage!!" + damage);
        Respawn();
    }

    void Respawn()
    {
        Debug.Log("Respawn - playerPosition:" + gameObject.transform.position);
        Debug.Log("Respawn - new Position:" + respawnPoint);
        gameObject.transform.position = respawnPoint;

    }

}
