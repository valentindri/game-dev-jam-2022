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
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()//updating together w the physics engine inside unity, so it's not depending on the frame rate
    {
        rb2D.AddForce(new Vector2(moveHorizontal * (isGrounded? moveSpeed : moveSpeed / 2) * Time.deltaTime, 0));
        
        Jump();
    }

    void Jump()
    {
        float verticalVelocity = rb2D.velocity.y;
        if(isGrounded && verticalVelocity < 1)
        {
            rb2D.AddForce(new Vector2(0, moveVertical * jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //wasGrounded = isGrounded;
        if(rb2D.velocity.y > 30){
            GetDamage();
        }

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bush"|| collision.gameObject.tag == "Vehicle")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Hole")
        {
            Respawn();
        }  
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Vehicle" || collision.gameObject.tag == "Bush")
        {
            isGrounded = false;
        }
    }

    async void GetDamage()
    {
        Debug.Log("Received damage!!");
        //disabled = true;
        //gameObject.SetActive(false);
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadEgg;
        await Task.Delay(1500);
        Respawn();
    }
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
