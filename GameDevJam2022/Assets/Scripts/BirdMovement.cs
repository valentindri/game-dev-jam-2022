using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private bool dirRight = true;
    public float speed = 5f;

    void Update()
    {
        
        transform.Translate((dirRight? Vector2.right : Vector2.left) * speed * Time.deltaTime);

        dirRight = transform.position.x >= 15f ? false : true;

    }
}