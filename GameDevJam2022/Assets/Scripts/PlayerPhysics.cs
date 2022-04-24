using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] public float fallThresholdVelocity = 1f;
    private float maxYvelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();//gameobject references the object the script is attached to (Player)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //bool previousGrounded = isGrounded;

        
        ////Debug.Log(previousGrounded);
        ////Debug.Log(isGrounded);
        //if (!previousGrounded && isGrounded)
        //{
        //    float asd = rb2D.velocity.y + fallThresholdVelocity;

        //    Debug.Log(asd);

        //    float damage = Mathf.Abs(rb2D.velocity.y);
        //    //Debug.Log("damash"+damage);
        //    if (rb2D.velocity.y < -fallThresholdVelocity)
        //    {
        //        GetDamage(damage);
        //    }
        //}
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
        Debug.Log("Received damage!!" + damage);
    }

}
