using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float fallThresholdVelocity = 1f;
    private bool isGrounded;
    private float moveHorizontal;
    private float moveVertical;
    private float maxYvelocity;


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
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed,0f), ForceMode2D.Impulse);
        }

        if(isGrounded && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool previousGrounded = isGrounded;

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush")
        {
            isGrounded = true;
        }
        //Debug.Log(previousGrounded);
        //Debug.Log(isGrounded);
        if (!previousGrounded && isGrounded)
        {
            float asd = rb2D.velocity.y + fallThresholdVelocity;

            Debug.Log(asd);

            float damage = Mathf.Abs(rb2D.velocity.y);
            //Debug.Log("damash"+damage);
            if (rb2D.velocity.y < -fallThresholdVelocity)
            {
                GetDamage(damage);
            }
        }
    }
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bush" && collision.gameObject.tag != "Bouncy")
        {
            //Debug.Log("Not a bush "+" Collision speed:"+GetComponent<Rigidbody2D>().velocity.magnitude);
            //Debug.Log("Not a bush "+" Collision :"+GetComponent<Rigidbody2D>().velocity);

            Vector2 impactVelocity = collision.relativeVelocity;
            float minimumDamageThreshold = 20f;
            float collisionDamageScale = 10;

            // Subtracting a minimum threshold can avoid tiny scratches at negligible speeds.
            float magnitude = Mathf.Max(0f, impactVelocity.magnitude - minimumDamageThreshold);

            // Using sqrMagnitude can feel good here,
            // making light taps less damaging and high-speed strikes devastating.

            float damage = magnitude * collisionDamageScale;
            //Debug.Log("Impact velocity: " +collision.relativeVelocity);
            //Debug.Log("Impact magnitude: " +collision.relativeVelocity.magnitude );
            //Debug.Log("Damage: " + damage);
            
        }





    }

    void GetDamage(float damage)
    {
        Debug.Log("Received damage!!"+ damage );
    }
    
}
