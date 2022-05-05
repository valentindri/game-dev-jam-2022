using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;


    private Vector2 respawnPoint;
    private float moveHorizontal;
    private float moveVertical;

    private bool disabled;
    private bool isGrounded;
    //private bool wasGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled) return;
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
        //wasGrounded = isGrounded;
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush"|| collision.gameObject.tag == "Vehicle")
        {
            isGrounded = true;

            //if (collision.gameObject.tag == "Platform"|| collision.gameObject.tag == "Obstacle")
            //{
            //    float playerVelocity = Mathf.Abs(rb2D.velocity.y);
            //    Debug.Log("player velocity" + playerVelocity);

                //if (!wasGrounded && isGrounded && playerVelocity > fallThresholdVelocity)
                //{
                //    GetDamage(playerVelocity, gameObject.transform.position);
                //    Debug.Log("Damage" + playerVelocity);
                //}
        }

        else if (collision.gameObject.tag == "Hole")
        {
            Respawn();
        }
        
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Vehicle")
        {
            isGrounded = false;
        }

       // Debug.Log("Trigger exit");

    }

    //async void GetDamage(float damage, Vector2 position)
    //{
    //    Debug.Log("Received damage!!" + damage);
    //    disabled = true;
    //    gameObject.SetActive(false);
    //    this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadEgg;
    //    await Task.Delay(1500);
    //    Respawn();
    //}
    //We're not proud of this. Don't judge us please


    void Respawn()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.angularVelocity = 0f;
        gameObject.transform.position = respawnPoint;
        //disabled = false;
        //gameObject.SetActive(true);

    }

}
